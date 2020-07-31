using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brokerage.Controllers.Resources;
using Brokerage.Core;
using Brokerage.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Brokerage.Controllers.Houses
{
    [Route("/api/houses/{houseId}/photos")]
    [ApiController]


    public class HousePhotoController : ControllerBase
    {

        private readonly IHouseRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;
        public HousePhotoController(IHouseRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<PhotoSettings> options)
        {
            this.photoSettings = options.Value;           
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(int houseId, IFormFile file)
        {
            var house = await repository.GetHouse(houseId, includeRelated: false);
            if (house == null)
                return NotFound();

            if (file == null)
                return BadRequest("Null File");
            if (file.Length == 0) return BadRequest("Empty File");
            if (file.Length > photoSettings.MaxBytes) return BadRequest("Max file size exceeded");
            if (!photoSettings.IsSupported(file.FileName)) return BadRequest("Invalid file type.");

            var uploadsFolderPath = Path.Combine("/Projects/Brokerage/ClientApp/src/assets/img", "houseUploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            // Generate Tumbnail

            var photo = new HousePhoto { FileName = fileName };
            house.Photos.Add(photo);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<HousePhoto, PhotoResource>(photo));
        }
    }
}