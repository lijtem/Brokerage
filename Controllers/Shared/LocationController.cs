using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brokerage.Core;
using Brokerage.Core.Models;
using Brokerage.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brokerage.Controllers.Shared
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILocationRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public LocationController(ApplicationDbContext context, IMapper mapper, ILocationRepository repository, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeLocation(int id)
        {
            var location = await repository.GetLocation(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] Location location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.Add(location);
            await unitOfWork.CompleteAsync();

            return Ok(location.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await repository.GetLocation(id);

            if (location == null)
                return NotFound();

            repository.Remove(location);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] Location locations)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var location = await repository.GetLocation(id);

            if (location == null)
                return NotFound();

            location.Name = locations.Name;

            await unitOfWork.CompleteAsync();

            return Ok(location);
        }
    }
}
