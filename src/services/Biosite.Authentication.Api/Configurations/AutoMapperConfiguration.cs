using Biosite.Domain.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Biosite.Authentication.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(PlanProfile),
                typeof(AreaProfile),
                typeof(UserProfile)
            );

            return services;
        }
    }
}
