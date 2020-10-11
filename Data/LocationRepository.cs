using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Data
{
    public class LocationRepository: ILocationRepository
    {
        private readonly ApplicationDbContext context;
        public LocationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Location location)
        {
            context.Locations.Add(location);
        }

        public async Task<Location> GetLocation(int id)
        {
            return await context.Locations.SingleOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(Location location)
        {
            context.Locations.Remove(location);
        }
    }
}
