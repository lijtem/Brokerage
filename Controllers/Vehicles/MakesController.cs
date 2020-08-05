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

namespace Brokerage.Controllers.Vehicles
{
    [Route("/api/makes")]
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IMakeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public MakesController(ApplicationDbContext context, IMapper mapper, IMakeRepository repository, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
             this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMake([FromBody] Make make)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            repository.Add(make);
            await unitOfWork.CompleteAsync();  
            
            return Ok(make.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var make= await repository.GetMake(id);

            if (make == null)
                return NotFound();

            repository.Remove(make);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMake(int id, [FromBody] Make makes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var make = await repository.GetMake(id);

            if (make == null)
                return NotFound();

            make.Name = makes.Name;

            await unitOfWork.CompleteAsync();

            return Ok(make);
        }
    }
}