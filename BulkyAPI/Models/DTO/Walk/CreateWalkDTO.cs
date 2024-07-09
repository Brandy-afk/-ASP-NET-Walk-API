using System.ComponentModel.DataAnnotations;

namespace BulkyAPI.Models.DTO.Walk
{
    public class CreateWalkDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(0,50)]
        public double LengthInKm { get; set; }
        public Guid? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyID { get; set; }
        [Required]
        public Guid RegionID { get; set; }
    }
}
