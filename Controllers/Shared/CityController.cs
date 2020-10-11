using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brokerage.Controllers.Resources;
using Brokerage.Core;
using Brokerage.Core.Models;
using Brokerage.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brokerage.Controllers.Shared
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ICityRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public CityController(ApplicationDbContext context, IMapper mapper, ICityRepository repository, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetCities()
        {
            var city = await context.Cities.Include(m => m.Locations).ToListAsync();

            return mapper.Map<List<City>, List<CityResource>>(city);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.Add(city);
            await unitOfWork.CompleteAsync();

            return Ok(city.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await repository.GetCity(id);
            if (city == null)
                return NotFound();

            repository.Remove(city);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _city = await repository.GetCity(id);

            if (_city == null)
                return NotFound();

            _city.Name = city.Name;

            await unitOfWork.CompleteAsync();

            return Ok(_city);
        }
    }
}
