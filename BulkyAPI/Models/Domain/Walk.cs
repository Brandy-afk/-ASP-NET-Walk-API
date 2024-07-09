using BulkyAPI.Models.DTO.Walk;

namespace BulkyAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }

        public Guid? ImageID { get; set; }
        public Guid DifficultyID { get; set; }
        public Guid RegionID { get; set; }
        public Image? Image { get; set; }
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

        public void Update(UpdateWalkDTO walk)
        {
            Name = walk.Name;
            Description = walk.Description;
            LengthInKm = walk.LengthInKm;
            ImageID = walk.ImageID;
            DifficultyID = walk.DifficultyID;
            RegionID = walk.RegionID;
        }

    }
}
