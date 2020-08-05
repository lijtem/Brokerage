using Brokerage.Core;
using Brokerage.Core.Models;
using Brokerage.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Brokerage.Data
{
    public class MakeRepository : IMakeRepository
    {
        private readonly ApplicationDbContext context;

        public MakeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Remove(Make make)
        {
            context.Makes.Remove(make);
        }

        public void Add(Make make)
        {
            context.Makes.Add(make);
        }

        public async Task<Make> GetMake(int id)
        {
            return await context.Makes.SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}

