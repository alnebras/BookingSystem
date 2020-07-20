using AutoMapper;
using BookingSystem.DTOs.Doctors;
using BookingSystem.Models.DoctorDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Mapping.Doctors
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            // Mapp to Create New Doctor
            CreateMap<DoctorCreationDto, Doctor>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorDto>();

            // Mapp to Update Exsisting Doctor
            CreateMap<DoctorUpdateDto, Doctor>();

        }
    }
}
