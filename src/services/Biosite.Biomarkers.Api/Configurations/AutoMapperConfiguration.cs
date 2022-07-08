using Biosite.Domain.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Biosite.Biomarkers.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(BiomarkerProfile)
            );

            return services;
        }
    }
}
