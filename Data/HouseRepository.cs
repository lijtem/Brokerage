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
    public class HouseRepository : IHouseRepository
    {
        private readonly ApplicationDbContext context;

        public HouseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<House> GetHouse(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Houses.FindAsync(id);

            return await context.Houses
                .Include(v => v.Location).ThenInclude(vf => vf.City)
                .Include(v => v.HousePhotos)
                .SingleOrDefaultAsync(v => v.Id == id);

        }

        public async Task<QueryResult<House>> GetHouses(HouseQuery queryObj)
        {
            var result = new QueryResult<House>();

            var query = context.Houses
              .Include(v => v.Location)
                .ThenInclude(m => m.City)
                 .Include(v => v.HousePhotos)
              .AsQueryable();

            if (queryObj.CityId.HasValue)
                query = query.Where(v => v.Location.CityId == queryObj.CityId.Value);

            if (queryObj.LocationId.HasValue)
                query = query.Where(v => v.LocationId == queryObj.LocationId.Value);

            if (queryObj.IsOwner.HasValue)
                query = query.Where(v => v.IsOwner == queryObj.IsOwner.Value);

            if (queryObj.Code != null)
                query = query.Where(v => v.Code.ToLower() == queryObj.Code.ToLower());


            var columnsMap = new Dictionary<string, Expression<Func<House, object>>>()
            {
                ["city"] = v => v.Location.City.Name,
                ["location"] = v => v.Location.Name,
                ["contactName"] = v => v.ContactName,
                ["code"] = v => v.Code
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

        public void Add(House house)
        {
            context.Houses.Add(house);
        }
        public void Remove(House house)
        {
            context.Houses.Remove(house);
        }

        
    }
}
