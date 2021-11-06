using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.Seed
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
