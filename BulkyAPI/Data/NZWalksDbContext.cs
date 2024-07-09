using BulkyAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BulkyAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public static List<Difficulty> difficulties = new List<Difficulty>
        {
            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = "Easy"
            },
            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = "Moderate"
            },
            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = "Difficult"
            },
            new Difficulty
            {
                Id = Guid.NewGuid(),
                Name = "Extreme"
            }
        };

        public static List<Region> regions = new List<Region>
        {
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "NA",
                Name = "North America",
                RegionImageUrl = "https://example.com/northamerica.jpg"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "EU",
                Name = "Europe",
                RegionImageUrl = "https://example.com/europe.jpg"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "AS",
                Name = "Asia",
                RegionImageUrl = "https://example.com/asia.jpg"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "AF",
                Name = "Africa",
                RegionImageUrl = "https://example.com/africa.jpg"
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Code = "SA",
                Name = "South America",
                RegionImageUrl = "https://example.com/southamerica.jpg"
            }
        };
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            modelBuilder.Entity<Region>().HasData(regions);
        }


    }
}
