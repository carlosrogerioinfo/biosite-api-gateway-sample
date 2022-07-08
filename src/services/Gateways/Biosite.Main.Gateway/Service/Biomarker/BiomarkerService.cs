using Biosite.Core.Extensions;
using Biosite.Main.Gateway.Response.Biomarker;
using Biosite.Main.Gateway.Service.Base;
using System.Net.Http.Headers;

namespace Biosite.Main.Gateway.Service.Biomarker
{
    public class BiomarkerService : ServiceBase
    {
        public readonly HttpClient _httpClient;

        public BiomarkerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<BiomarkerResponse>> GetAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("bearer", string.Empty).Replace("Bearer", string.Empty).Trim());

             var response = await _httpClient
                .GetJsonAsync($"biomarker/crud/get");

            if (!ResponseErrorHandling(response))
                return null;// await response.Content.ReadJsonAsync<BiomarkerResponse>("error"); //Esta rotina de tratamento de erro será melhorada

            return await response.Content.ReadJsonAsync<ICollection<BiomarkerResponse>>("data");
        }
    }
}