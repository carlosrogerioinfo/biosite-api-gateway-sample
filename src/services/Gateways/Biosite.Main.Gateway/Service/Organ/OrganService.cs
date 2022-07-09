using Biosite.Core.Extensions;
using Biosite.Main.Gateway.Response.Organ;
using Biosite.Main.Gateway.Service.Base;

namespace Biosite.Analysis.Gateway.Services.Authentication
{
    public class OrganService : ServiceBase
    {
        public readonly HttpClient _httpClient;

        public OrganService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<OrganResponse>> GetAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"organ/crud/get");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<ICollection<OrganResponse>>("data");
        }
    }
}