using Biosite.Core;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories;
using Biosite.Infrastructure.Transactions;
using Biosite.Organs.Api.Application.Commands.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Biosite.Organs.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<BiositeDataContext>(opt => opt.UseSqlServer(Runtime.ConnectionString), ServiceLifetime.Scoped);

            services.AddScoped<IUow, Uow>();

            services.AddScoped<IOrganRepository, OrganRepository>();
            services.AddScoped<OrganCommandHandler, OrganCommandHandler>();

            return services;
        }
    }
}
