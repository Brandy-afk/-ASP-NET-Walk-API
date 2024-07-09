using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Region;

namespace BulkyAPI.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAllAsync();
        public Task<Region> GetAsync(Guid id);
        public Task<Region> CreateAsync(RegionsCreateRequestDTO request);
        public Task<Region?> UpdateAsync(Guid id, UpdateRegionRequestDTO request);
        public Task<Region?> DeleteAsync(Guid id);
    }
}
