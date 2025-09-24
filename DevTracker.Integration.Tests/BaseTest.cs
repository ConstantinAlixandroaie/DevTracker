using DevTracker.API;
using DevTracker.Data;
using DevTracker.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace DevTracker.Integration.Tests;

public class BaseTest : IClassFixture<CustomWebApplicationFactory<Program>>, IAsyncLifetime
{
    protected readonly HttpClient HttpClient;
    protected readonly CustomWebApplicationFactory<Program> Factory;

    protected const string TestUserEmail = "testuser@example.com";
    protected const string TestUserPassword = "Pass123$";
    protected long? TestUserId { get; private set; }

    protected BaseTest(CustomWebApplicationFactory<Program> factory)
    {
        Factory = factory;
        HttpClient = factory.CreateClient();
    }

    public async ValueTask InitializeAsync()
    {
        await SeedTestUserAsync();
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    protected async Task SeedTestUserAsync()
    {
        using var scope = Factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DevTrackerContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        await context.Database.EnsureCreatedAsync();

        var existingUser = await userManager.FindByEmailAsync(TestUserEmail);
        if (existingUser != null)
        {
            TestUserId = existingUser.Id;
            return;
        }

        var testUser = new User
        {
            UserName = TestUserEmail,
            Email = TestUserEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(testUser, TestUserPassword);
        if (result.Succeeded)
        {
            TestUserId = testUser.Id;
        }
        else
        {
            throw new InvalidOperationException($"Failed to create test user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    protected async Task<string> GetAuthTokenAsync()
    {
        var loginData = new
        {
            email = TestUserEmail,
            password = TestUserPassword
        };

        var response = await HttpClient.PostAsJsonAsync("/api/v1/Identity/login", loginData);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException($"Login failed: {response.StatusCode} - {error}");
        }

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        return json.GetProperty("accessToken").GetString()!;
    }

    protected async Task AuthenticateAsync()
    {
        var token = await GetAuthTokenAsync();
        HttpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    protected async Task<T> SeedEntityAsync<T>(T entity) where T : class
    {
        using var scope = Factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DevTrackerContext>();

        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
