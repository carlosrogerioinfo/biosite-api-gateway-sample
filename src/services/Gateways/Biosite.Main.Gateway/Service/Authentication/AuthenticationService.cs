using Biosite.Analysis.Gateway.Request;
using Biosite.Core.Extensions;
using Biosite.Main.Gateway.Response.Authentication;
using Biosite.Main.Gateway.Service.Base;

namespace Biosite.Analysis.Gateway.Services.Authentication
{
    public class AuthenticationService : ServiceBase
    {
        public readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponse> Authentication(AuthenticationRequest request)
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient
                .PostJsonAsync($"login", request);

            if (!ResponseErrorHandling(response)) 
                return default;

            return await response.Content.ReadJsonAsync<UserResponse>("data");
        }

        public async Task<ICollection<UserResponse>> GetAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
               .GetJsonAsync($"user/crud/get");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<ICollection<UserResponse>>("data");
        }
    }
}