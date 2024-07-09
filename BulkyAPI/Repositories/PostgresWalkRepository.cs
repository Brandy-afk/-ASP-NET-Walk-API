using AutoMapper;
using BulkyAPI.Data;
using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Walk;
using Microsoft.EntityFrameworkCore;

namespace BulkyAPI.Repositories
{
    public class PostgresWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext db;
        private readonly IMapper mapper;

        public PostgresWalkRepository(NZWalksDbContext db, IMapper map)
        {
            this.db = db;
            this.mapper = map;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = db.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }

                if(!string.IsNullOrWhiteSpace(sortBy))
                {
                    if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                    }
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
          //  return await db.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await db.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> CreateAsync(CreateWalkDTO request)
        {
            var newWalk = mapper.Map<Walk>(request);
            await db.Walks.AddAsync(newWalk);
            await db.SaveChangesAsync();
            return newWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
          var removedWalk = await GetAsync(id);
           db.Walks.Remove(removedWalk);
            await db.SaveChangesAsync();
            return removedWalk;
        }


        public async Task<Walk?> UpdateAsync(Guid id, UpdateWalkDTO request)
        {
            var rawWalk = await GetAsync(id);
            if (rawWalk != null)
            {
                rawWalk.Update(request);
                await db.SaveChangesAsync();
            }

            return rawWalk;
        }

       
    }
}
