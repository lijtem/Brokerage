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
    [Route("/api/remarks")]
    [ApiController]
    public class RemarksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRemarkRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public RemarksController(IMapper mapper, IRemarkRepository repository, IUnitOfWork unitOfWork)
        {           
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddRemark([FromBody] Remark remark)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.Add(remark);
            await unitOfWork.CompleteAsync();

            return Ok(remark.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRemarks(int id)
        {
            var remarks = await repository.GetRemarks(id);
            if (remarks == null)
                return NotFound();
            return Ok(remarks);
        }
    }
}
