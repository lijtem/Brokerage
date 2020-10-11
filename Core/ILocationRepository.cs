using Brokerage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface ILocationRepository
    {
        void Add(Location location);
        void Remove(Location location);
        Task<Location> GetLocation(int id);
    }
}
