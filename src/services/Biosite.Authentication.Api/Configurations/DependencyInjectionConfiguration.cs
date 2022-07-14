using Biosite.Authentication.Api.Application.Commands.Handlers;
using Biosite.Core;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories;
using Biosite.Infrastructure.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biosite.Authentication.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<BiositeDataContext>(opt => opt.UseSqlServer(Runtime.ConnectionString), ServiceLifetime.Scoped);

            services.AddScoped<IUow, Uow>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserCommandHandler>();

            return services;
        }
    }
}
