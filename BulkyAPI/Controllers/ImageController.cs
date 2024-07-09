using AutoMapper;
using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Image;
using BulkyAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository repo;
        private readonly IMapper mapper;

        public ImageController(IImageRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);
            if(ModelState.IsValid)
            {
                //Convert to Domain Model
                var newImage = new Image
                {
                    File = request.File,
                    FileName = request.FileName,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileDescription = request.FileDescription

                };

               await repo.Upload(newImage);
               return Ok(mapper.Map<ImageDTO>(newImage));
            }
            return BadRequest(ModelState);

        }

        private void ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jped", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension!");
            }

            if (request.File.Length > 10485760 )
            {
                ModelState.AddModelError("size", "File is larger then 10 mb!");
            }
        }


    }
}
