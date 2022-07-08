using Biosite.Core.Extensions;
using Biosite.Main.Gateway.Response.Organ;
using Biosite.Main.Gateway.Service.Base;
using System.Net.Http.Headers;

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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("bearer", string.Empty).Replace("Bearer", string.Empty).Trim());

            var response = await _httpClient
                .GetJsonAsync($"organ/crud/get");

            if (!ResponseErrorHandling(response))
                return null;// await response.Content.ReadJsonAsync<OrganResponse>("error"); //Esta rotina de tratamento de erro será melhorada

            return await response.Content.ReadJsonAsync<ICollection<OrganResponse>>("data");
        }
    }
}