using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Region;
using BulkyAPI.Models.DTO.Walk;

namespace BulkyAPI.Repositories
{
    public interface IWalkRepository
    {
        public Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, 
            bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        public Task<Walk> GetAsync(Guid id);
        public Task<Walk> CreateAsync(CreateWalkDTO request);
        public Task<Walk?> UpdateAsync(Guid id, UpdateWalkDTO request);
        public Task<Walk?> DeleteAsync(Guid id);

    }
}
