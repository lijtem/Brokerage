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
    [Route("/api/models")]
    public class ModelsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IModelRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public ModelsController(ApplicationDbContext context, IMapper mapper, IModelRepository repository, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
             this.unitOfWork = unitOfWork;
        }


        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel(int id)
        {
            var models = await repository.GetModel(id);
            if (models == null)
                return NotFound();

            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel([FromBody] Model model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            repository.Add(model);
            await unitOfWork.CompleteAsync();  
            
            return Ok(model.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemodel(int id)
        {
            var model= await repository.GetModel(id);

            if (model == null)
                return NotFound();

            repository.Remove(model);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatemodel(int id, [FromBody] Model models)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await repository.GetModel(id);

            if (model == null)
                return NotFound();

            model.Name = models.Name;

            await unitOfWork.CompleteAsync();

            return Ok(model);
        }
    }
}