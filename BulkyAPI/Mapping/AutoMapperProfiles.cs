using AutoMapper;
using BulkyAPI.Models.Domain;
using BulkyAPI.Models.DTO.Difficulty;
using BulkyAPI.Models.DTO.Image;
using BulkyAPI.Models.DTO.Region;
using BulkyAPI.Models.DTO.Walk;

namespace BulkyAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles() {
            CreateMap<Region, RegionsDTO>().ReverseMap();
            CreateMap<RegionsCreateRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();
            CreateMap<Walk, WalksDTO>().ReverseMap();
            CreateMap<Walk, CreateWalkDTO>().ReverseMap();
            CreateMap<Walk, UpdateWalkDTO>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();
        }
        
    }
}
