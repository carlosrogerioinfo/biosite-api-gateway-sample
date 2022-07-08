using Biosite.Analysis.Gateway.Services.Authentication;
using Biosite.Main.Gateway.Service.Biomarker;
using System.Net.Http.Headers;

namespace Biosite.Analysis.Gateway.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient<AuthenticationService, AuthenticationService>(config =>
            {
                config.BaseAddress = new Uri("http://authentication.sampleapicore.uni5.net");
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<BiomarkerService, BiomarkerService>(config =>
            {
                config.BaseAddress = new Uri("http://biomarker.sampleapicore.uni5.net");
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<OrganService, OrganService>(config =>
            {
                config.BaseAddress = new Uri("http://organ.sampleapicore.uni5.net");
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
