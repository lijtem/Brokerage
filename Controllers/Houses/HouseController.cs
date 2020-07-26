using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brokerage.Controllers.Resources;
using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brokerage.Controllers.Houses
{
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
    }
}
