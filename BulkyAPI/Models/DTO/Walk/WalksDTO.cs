

using BulkyAPI.Models.DTO.Difficulty;
using BulkyAPI.Models.DTO.Image;
using BulkyAPI.Models.DTO.Region;

namespace BulkyAPI.Models.DTO.Walk
{
    public class WalksDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        
        public ImageDTO? Image { get; set; }
        public DifficultyDTO Difficulty { get; set; }
        public RegionsDTO Region { get; set; }

    }
}
