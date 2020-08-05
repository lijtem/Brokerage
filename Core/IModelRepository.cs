using Brokerage.Core.Models;
using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface IModelRepository
    {
        void Add(Model make);
        void Remove(Model make);
        Task<Model> GetModel(int id);
    }
}
