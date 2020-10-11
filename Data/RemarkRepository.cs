using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Brokerage.Data
{
    public class RemarkRepository : IRemarkRepository
    {
        private readonly ApplicationDbContext context;
        public RemarkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Remark remark)
        {
            context.Remarks.Add(remark);
        }

        public async Task<Remark> GetRemarks(int id)
        {
            return await context.Remarks.SingleOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(Remark remark)
        {
            context.Remarks.Remove(remark);
        }
    }
}
