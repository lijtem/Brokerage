using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brokerage.Controllers.Resources;
using Brokerage.Core.Models;
using Brokerage.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brokerage.Controllers.Houses
{
    
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LocationController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        [HttpGet("/api/locations")]
        public async Task<IEnumerable<CityResource>> GetLocations()
        {
            var location = await context.Cities.Include(m => m.Locations).ToListAsync();

            return mapper.Map<List<City>, List<CityResource>>(location);
        }
    }
}
