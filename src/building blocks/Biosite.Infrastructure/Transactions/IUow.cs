using System.Threading.Tasks;

namespace Biosite.Infrastructure.Transactions
{
    public interface IUow
    {
        Task Commit();
        void Rollback();
    }
}
