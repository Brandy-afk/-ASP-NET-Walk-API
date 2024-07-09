using AutoMapper;
using BulkyAPI.CustomFilterActions;
using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Walk;
using BulkyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BulkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository repo;

        public WalksController(IMapper map, IWalkRepository repo)
        {
            this.mapper = map;
            this.repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? queryString, [FromQuery] string? sortOn,
            [FromQuery] bool? isAscending, [FromQuery] int? pageNumber, [FromQuery] int? pageSize) {
            var rawWalks = await repo.GetAllAsync(filterOn, queryString, sortOn, isAscending ?? true, pageNumber ?? 1, pageSize ?? 1000);
            List<WalksDTO> walks = rawWalks.Select(w => mapper.Map<WalksDTO>(w)).ToList();
            return Ok(walks);
        } 


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var walk = await repo.GetAsync(id);
            if (walk == null)
                return NotFound();
            return Ok(mapper.Map<WalksDTO>(walk));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateWalkDTO request)
        {
            Walk newWalk = await repo.CreateAsync(request);
            WalksDTO dto = mapper.Map<WalksDTO>(newWalk);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDTO request)
        {

            Walk updatedWalk = await repo.UpdateAsync(id, request);
            if (updatedWalk == null) return NotFound();
            return Ok(mapper.Map<WalksDTO>(updatedWalk));

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalk = await repo.DeleteAsync(id);
            if (deletedWalk == null) return NotFound();
            return Ok(mapper.Map<WalksDTO>(deletedWalk));
        }
    }
}
