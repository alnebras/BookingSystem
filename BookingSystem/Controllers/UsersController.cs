using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Users;
using BookingSystem.Models.Users;
using BookingSystem.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        // Register New User
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return NotFound();

            var user_Dto = await _usersRepository.Register(userDto).ConfigureAwait(false);
            return user_Dto; ;
        }


        // Login New User
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return NotFound();

            return await _usersRepository.Login(userDto);
        }


        // Get Current Information Logged User 
 
        [Authorize]
        [HttpGet("currentUserDetails")]
        public User CurrentUser()
        {
            return _usersRepository.GetCurrentUserDetails();
        }
        [Authorize]
        [HttpGet("currentUserId")]
        public Guid CurrentUserId()
        {
            return _usersRepository.GetCurrentUserId();
        }
    }
}