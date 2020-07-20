
using BookingSystem.DTOs.Users;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<UserDto> Register(UserDto userDto);
        Task<IActionResult> Login(UserDto dto);
        User GetCurrentUserDetails();
        Guid GetCurrentUserId();

    }
}
