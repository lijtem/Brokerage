using Brokerage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brokerage.Core
{
    public interface IHouseRepository
    {
        Task<House> GetHouse(int id, bool includeRelated = true);
        void Add(House house);
        void Remove(House house);
        Task<QueryResult<House>> GetHouses(HouseQuery filter);
    }
}