using Biosite.Core.Extensions;
using Biosite.Main.Gateway.Response.Biomarker;
using Biosite.Main.Gateway.Service.Base;

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
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"biomarker/crud/get");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<ICollection<BiomarkerResponse>>("data");
        }
    }
}