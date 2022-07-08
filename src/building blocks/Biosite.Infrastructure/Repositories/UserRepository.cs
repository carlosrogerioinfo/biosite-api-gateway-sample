using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biosite.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BiositeDataContext context) : base(context)
        {
        }

        #region IMPLEMENTAÇÕES ADICIONAIS

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _dbSet
                .Include("Plan")
                .Include("Plan.PlanAreas")
                .Include("Plan.PlanAreas.Area")
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User> LoginUserAsync(string email, string password)
        {
            var user = await _dbSet
                .Include("Plan")
                .Include("Plan.PlanAreas")
                .Include("Plan.PlanAreas.Area")
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Email.Equals(email)
                    && x.Password.Equals(password));

            return user;
        }

        #endregion
    }

}
