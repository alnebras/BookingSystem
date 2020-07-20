using AutoMapper;
using BookingSystem.DTOs.Doctors.Specializations;
using BookingSystem.Models.DoctorDomain;

namespace BookingSystem.Mapping.Specializations
{
    public class SpecializationProfile:Profile
    {
        public SpecializationProfile()
        {
            // Mapp to Create New Specialization
            CreateMap<SpecializationCreationDto, Specialization>();
            CreateMap<SpecializationDto, Specialization>();
            CreateMap<Specialization, SpecializationDto>();

            // Mapp to Update Exsisting Specialization
            CreateMap<SpecializationUpdateDto, Specialization>();

        }
    }
}
