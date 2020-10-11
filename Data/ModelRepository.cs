using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Brokerage.Data
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext context;

        public ModelRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Remove(Model model)
        {
            context.Models.Remove(model);
        }

        public void Add(Model model)
        {
            context.Models.Add(model);
        }

        public async Task<Model> GetModel(int id)
        {
            return await context.Models.SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}

