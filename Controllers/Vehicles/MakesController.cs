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

namespace Brokerage.Controllers.Vehicles
{
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MakesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}