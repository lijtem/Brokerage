using Brokerage.Core.Models;
using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface IMakeRepository
    {
        void Add(Make make);
        void Remove(Make make);
        Task<Make> GetMake(int id);
    }
}
