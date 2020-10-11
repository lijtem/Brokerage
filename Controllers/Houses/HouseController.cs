using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brokerage.Controllers.Resources;
using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brokerage.Controllers.Houses
{
   // [Authorize]
    //[ApiController]
    [Route("/api/houses")]
    public class HouseController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IHouseRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public HouseController(IMapper mapper, IHouseRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouse([FromBody] SaveHouseResource houseResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var house = mapper.Map<SaveHouseResource, House>(houseResource);
            house.LastUpdate = DateTime.Now;

            repository.Add(house);
            await unitOfWork.CompleteAsync();

            house = await repository.GetHouse(house.Id);

            var result = mapper.Map<House, HouseResource>(house);

            return Ok(result);
        }
        [HttpGet]
        public async Task<QueryResultResource<HouseResource>> GetHouses(HouseQueryResource filterResource)
        {
            var filter = mapper.Map<HouseQueryResource, HouseQuery>(filterResource);
            var queryResult = await repository.GetHouses(filter);

            return mapper.Map<QueryResult<House>, QueryResultResource<HouseResource>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHouse(int id)
        {
            var house = await repository.GetHouse(id);

            if (house == null)
                return NotFound();

            var houseResource = mapper.Map<House, HouseResource>(house);

            return Ok(houseResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHouse(int id, [FromBody] SaveHouseResource houseResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var house = await repository.GetHouse(id);
            if (house == null)
                return NotFound();

            mapper.Map<SaveHouseResource, House>(houseResource, house);
            house.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            house = await repository.GetHouse(house.Id);
            var result = mapper.Map<House, HouseResource>(house);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var house = await repository.GetHouse(id, includeRelated: false);

            if (house == null)
                return NotFound();

            repository.Remove(house);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
