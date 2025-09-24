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
        builder.ConfigureServices(services =>
        {
            builder.UseSetting("ConnectionStrings:DefaultConnection", "InMemory");

            builder.ConfigureServices(services =>
            {
                // Remove the SQL Server DbContext registration
                services.RemoveAll(typeof(DbContextOptions<DevTrackerContext>));
                services.RemoveAll(typeof(DevTrackerContext));
                services.RemoveAll<DbConnection>();

                // Add InMemory database
                services.AddDbContext<DevTrackerContext>(options =>
                {
                    options.UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}");
                });
            });

            builder.UseEnvironment("Testing");
        });
    }
}