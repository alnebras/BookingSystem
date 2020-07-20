using AutoMapper;
using BookingSystem.DTOs.Patents;
using BookingSystem.Models.PatentsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Mapping.Patents
{
    public class PatentProfile:Profile
    {
        public PatentProfile()
        {
            // Mapp to Create New Patent
            CreateMap<PatentCreationDto, Patent>();
            CreateMap<PatentDto, Patent>();
            CreateMap<Patent, PatentDto>();

            // Mapp to Update Exsisting Patent
            CreateMap<PatentUpdateDto, Patent>();

        }
    }
}
