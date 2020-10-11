using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Data
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext context;
        public CityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(City city)
        {
            context.Cities.Add(city);
        }

        public async Task<City> GetCity(int id)
        {
            return await context.Cities.SingleOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(City city)
        {
            context.Cities.Remove(city);
        }
    }
}
