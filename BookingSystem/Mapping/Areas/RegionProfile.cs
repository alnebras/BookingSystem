using AutoMapper;
using BookingSystem.DTOs.Areas;
using BookingSystem.Models.Areas;

namespace BookingSystem.Mapping.Regions
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            // Mapp to Create New Region
            CreateMap<RegionCreationDto, Region>();
            CreateMap<RegionDto, Region>();
            CreateMap<Region, RegionDto>();

            // Mapp to Update Exsisting Region
            CreateMap<RegionUpdateDto, Region>();

        }
    }
}
