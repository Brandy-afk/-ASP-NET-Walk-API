using System.ComponentModel.DataAnnotations;

namespace BulkyAPI.Models.DTO.Walk
{
    public class UpdateWalkDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name is too long!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = "No way you ran that far! Too large!")]
        public double LengthInKm { get; set; }
        public Guid? ImageID { get; set; }
        [Required]
        public Guid DifficultyID { get; set; }
        [Required]
        public Guid RegionID { get; set; }
    }
}
