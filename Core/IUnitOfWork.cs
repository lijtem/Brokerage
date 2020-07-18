using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
