using Biosite.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace Biosite.Infrastructure.Transactions
{
    public class Uow : IUow
    {
        private readonly BiositeDataContext _context;

        public Uow(BiositeDataContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            // Do Nothing
        }
    }
}
