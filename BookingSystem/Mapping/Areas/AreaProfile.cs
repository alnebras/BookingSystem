using AutoMapper;
using BookingSystem.DTOs.Areas;
using BookingSystem.Models.Areas;
namespace BookingSystem.Mapping.Areas
{
    public class AreaProfile:Profile
    {
        public AreaProfile()
        {
            // Mapp to Create New Area
            CreateMap<AreaCreationDto, Area>();
            CreateMap<AreaDto, Area>();
            CreateMap<Area, AreaDto>();

            // Mapp to Update Exsisting Area
            CreateMap<AreaUpdateDto, Area>();

        }
    }
}
