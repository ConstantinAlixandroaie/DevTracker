using System.Net.Http.Json;
using System.Text.Json;

namespace DevTracker.Integration.Tests;

public static class TestAuthorizationHelper
{
    public static async Task<string> LoginAsync(HttpClient client)
    {
        var loginData = new
        {
            email = "testuser@example.com",
            password = "Pass123$"
        };

        var response = await client.PostAsJsonAsync("/api/v1/Identity/login", loginData);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        return json.GetProperty("accessToken").GetString()!;
    }
}
