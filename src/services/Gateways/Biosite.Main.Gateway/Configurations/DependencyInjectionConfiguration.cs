using Biosite.Analysis.Gateway.Services.Authentication;
using Biosite.Main.Gateway.Service.Biomarker;
using System.Net.Http.Headers;

namespace Biosite.Analysis.Gateway.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddHttpClient<AuthenticationService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection("BaseUrl")["AuthenticationApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<BiomarkerService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection("BaseUrl")["BiomarkerApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<OrganService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection("BaseUrl")["OrganApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
