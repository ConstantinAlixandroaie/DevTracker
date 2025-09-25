using DevTracker.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data.Common;

namespace DevTracker.Integration.Tests;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting("ConnectionStrings:DefaultConnection", "InMemory");

        builder.ConfigureServices(services =>
        {
            var newServices = new ServiceCollection();

            foreach (var service in services)
            {
                if (IsEntityFrameworkService(service) && !IsIdentityService(service))
                    continue;

                newServices.Add(service);
            }

            newServices.AddDbContext<DevTrackerContext>(options =>
            {
                options.UseInMemoryDatabase($"TestDb");
            });

            services.Clear();
            foreach (var service in newServices)
            {
                services.Add(service);
            }
        });
    }
    private static bool IsEntityFrameworkService(ServiceDescriptor service)
    {
        if (service.ServiceType == typeof(DevTrackerContext) ||
            service.ServiceType == typeof(DbContextOptions<DevTrackerContext>) ||
            service.ServiceType == typeof(DbContextOptions) ||
            service.ServiceType == typeof(DbConnection))
            return true;

        if (service.ServiceType.IsGenericType &&
            service.ServiceType.GetGenericTypeDefinition() == typeof(DbContextOptions<>))
            return true;

        if (service.ServiceType.Namespace?.StartsWith("Microsoft.EntityFrameworkCore") == true)
            return true;

        if (service.ImplementationType?.Assembly.FullName?.Contains("EntityFrameworkCore") == true)
            return true;

        if (service.ServiceType.FullName?.Contains("EntityFrameworkCore") == true)
            return true;

        return false;
    }
    private static bool IsIdentityService(ServiceDescriptor service)
    {
        // Preserve all Identity-related services
        return service.ServiceType.FullName?.Contains("Microsoft.AspNetCore.Identity") == true ||
               service.ServiceType.FullName?.Contains("IUserStore") == true ||
               service.ServiceType.FullName?.Contains("IRoleStore") == true ||
               service.ServiceType.FullName?.Contains("UserManager") == true ||
               service.ServiceType.FullName?.Contains("RoleManager") == true ||
               service.ServiceType.FullName?.Contains("SignInManager") == true;
    }
}