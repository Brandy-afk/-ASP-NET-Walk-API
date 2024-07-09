using AutoMapper;
using BulkyAPI.CustomFilterActions;
using BulkyAPI.Models.DTO.Region;
using BulkyAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : Controller
    {
        private readonly IRegionRepository repo;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController( IRegionRepository repo, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            var rawRegions = await repo.GetAllAsync();
            var regions = new List<RegionsDTO>();
            foreach (var region in rawRegions)
            {
                regions.Add(mapper.Map<RegionsDTO>(region));
            }

            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> Get([FromRoute] Guid id) { 
            var rawRegion = await repo.GetAsync(id);

            if(rawRegion == null)
            {
                return NotFound();
            }

            var region = mapper.Map<RegionsDTO>(rawRegion);

            return Ok(region);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] RegionsCreateRequestDTO request)
        {
            var newRegion = await repo.CreateAsync(request);
            var regionDto = mapper.Map<RegionsDTO>(newRegion);

            return CreatedAtAction(nameof(Get), new { id= regionDto.Id }, regionDto); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO request)
        {
            var updatedRegion = await repo.UpdateAsync(id, request);
            if (updatedRegion == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionsDTO>(updatedRegion));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedRegion = await repo.DeleteAsync(id);
            if (deletedRegion == null)
            {
                return NotFound(); 
            }
        
            return Ok(mapper.Map<RegionsDTO>(deletedRegion));
        }
    }
}
