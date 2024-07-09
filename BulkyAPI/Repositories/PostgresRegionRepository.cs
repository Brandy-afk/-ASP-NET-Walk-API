using AutoMapper;
using BulkyAPI.Data;
using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Region;
using BulkyAPI.Models.DTO.Walk;
using Microsoft.EntityFrameworkCore;


namespace BulkyAPI.Repositories
{
    public class PostgresRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext db;
        private readonly IMapper mapper;

        public PostgresRegionRepository(NZWalksDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<Region>> GetAllAsync() => await db.Regions.ToListAsync();
        public async Task<Region> GetAsync(Guid id) => await db.Regions.FindAsync(id);

        public async Task<Region> CreateAsync(RegionsCreateRequestDTO request)
        {
            var newRegion = mapper.Map<Region>(request);

            await db.Regions.AddAsync(newRegion);
            await db.SaveChangesAsync();
            return newRegion;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var deletedRegion = await GetAsync(id);
            if (deletedRegion != null)
            {
               db.Regions.Remove(deletedRegion);
               await db.SaveChangesAsync();
            }
            return deletedRegion;
        }


        public async Task<Region> UpdateAsync(Guid id, UpdateRegionRequestDTO request)
        {
            var rawRegion = await GetAsync(id);
            if (rawRegion != null)
            {
               rawRegion.Code = request.Code;
               rawRegion.Name = request.Name;
               rawRegion.RegionImageUrl = request.RegionImageUrl;
               await db.SaveChangesAsync();
            }

            return rawRegion;
        }
    }
}
