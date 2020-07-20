using AutoMapper;
using BookingSystem.DTOs.Users;
using BookingSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Mapping.Users
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();


            CreateMap<UserDto, User>().ForMember(dest => dest.IdentityId, opt => opt.MapFrom(src => new Identity(){Id = src.Id }));
        }
    }
}
