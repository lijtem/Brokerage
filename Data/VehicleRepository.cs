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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext context;

        public VehicleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles
                .Include(v => v.Features).ThenInclude(vf => vf.Feature)
                .Include(v => v.Model).ThenInclude(vf => vf.Make)
                .Include(v => v.Photos)
                .SingleOrDefaultAsync(v => v.Id == id);

        }
        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj)
        {
            var result = new QueryResult<Vehicle>();

            var query = context.Vehicles
              .Include(v => v.Model)
                .ThenInclude(m => m.Make)
              .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                 .Include(v => v.Photos)                 
                 .Include(v=> v.Remarks)
              .AsQueryable();

            if (queryObj.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == queryObj.MakeId.Value);

            if (queryObj.ModelId.HasValue)
                query = query.Where(v => v.ModelId == queryObj.ModelId.Value);

            if (queryObj.IsOwner.HasValue)
                query = query.Where(v => v.IsOwner == queryObj.IsOwner.Value);

            if (queryObj.Code != null)
                query = query.Where(v => v.Code.ToLower() == queryObj.Code.ToLower());
            if (queryObj.Name != null)
                query = query.Where(v => v.Remarks.Any(x=>x.Name.ToLower() == queryObj.Name.ToLower()));
            if (queryObj.Phone != null)
                query = query.Where(v => v.Remarks.Any(x => x.Phone.ToLower() == queryObj.Phone.ToLower()));


            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName,
                ["code"] = v => v.Code,
                //["name"] = v => v.Remark.Name,
            };

            query = query.ApplyOrdering(queryObj, columnsMap);
           // query = query.Where(v => v.Remarks == null);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }


        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }

    }
}

