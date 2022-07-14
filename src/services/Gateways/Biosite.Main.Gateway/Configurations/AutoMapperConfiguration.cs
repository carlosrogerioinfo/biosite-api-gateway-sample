using Health.Library.Domain.Profiles;

namespace Biosite.Analysis.Gateway.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CholecalciferolProfile)
            );

            return services;
        }
    }
}
