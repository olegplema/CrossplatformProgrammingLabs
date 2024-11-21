using App.Models;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace App.Services;

public class AuthService(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<bool> CreateUserAsync(SignUpViewModel model)
    {
        try
        {
            var managementClient = await GetManagementApiClientAsync();
            var userCreateRequest = new UserCreateRequest
            {
                Email = model.Email,
                Password = model.Password,
                Connection = "Username-Password-Authentication",
                EmailVerified = true,
                UserMetadata = new
                {
                    full_name = model.FullName,
                    phone_number = $"+380{model.PhoneNumber}",
                    username = model.Username,
                },
            };

            var user = await managementClient.Users.CreateAsync(userCreateRequest);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<User?> GetUserAsync(string id)
    {
        var managementClient = await GetManagementApiClientAsync();
        try
        {
            return await managementClient.Users.GetAsync(id);
        }
        catch
        {
            return null;
        }
    }

    private async Task<IManagementApiClient> GetManagementApiClientAsync()
    {
        var auth0Client = new AuthenticationApiClient(new Uri($"https://{_configuration["Auth0:Domain"]}"));
        var tokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _configuration["Auth0:ClientId"],
            ClientSecret = _configuration["Auth0:ClientSecret"],
            Audience = $"https://{_configuration["Auth0:Domain"]}/api/v2/"
        };
        var token = await auth0Client.GetTokenAsync(tokenRequest);
        return new ManagementApiClient(
            token.AccessToken,
            new Uri($"https://{_configuration["Auth0:Domain"]}/api/v2"));
    }
}
