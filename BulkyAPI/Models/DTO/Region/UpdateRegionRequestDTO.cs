using System.ComponentModel.DataAnnotations;

namespace BulkyAPI.Models.DTO.Region
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must be 3 characters")]
        [MaxLength(3, ErrorMessage = "Code must be 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name to large!")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
