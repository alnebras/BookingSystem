using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Users;
using System;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Repositories.Users;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BookingSystem.Helpers.Auth;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly DoctorBookingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Identity> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private string CurrentToken;
        public UsersRepository(DoctorBookingContext context, UserManager<Identity> userManager, IMapper mapper, IJwtFactory jwtFactory, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Generate Claims Function
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id.ToString()));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }

        /// <summary>
        /// Registeration Service
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<UserDto> Register(UserDto userDto)
        {
            User userEntity = new User();
            var user = _mapper.Map<User>(userDto);

            var userIdentity = new Identity { UserName = userDto.UserName };
            var result = await _userManager.CreateAsync(userIdentity, userDto.Password);

            if (result.Succeeded)
            {
                userDto.IdentityId = userIdentity.Id;
                user.IdentityId = userIdentity.Id;
                userEntity.UserType = userDto.UserType;
                await _context.Users.AddAsync(user).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                var user_Dto = _mapper.Map<UserDto>(user);
                return user_Dto;
            }
            else
            {
                return userDto;
            }

        }

        /// <summary>
        /// Login Service With Valid Token
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        public async Task<IActionResult> Login(UserDto Dto)
        {
            var identity = await GetClaimsIdentity(Dto.UserName, Dto.Password);
            if (identity == null)
            {
            }
            CurrentToken = await Tokens.GenerateJwt(identity, _jwtFactory, Dto.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(CurrentToken);

        }

        // Get Logged User Details
        public User GetCurrentUserDetails()
        {
            //User user = new User();
            var name = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var users = _context.Users.Include(u => u.Identity)
                     .FirstOrDefault(u => u.Identity.UserName == name);
            //var userdto = _mapper.Map<UserDto>(user);
            return users;
        }

        // Get Logged User Information
        public Guid GetCurrentUserId()
        {
            var name = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var users = _context.Users.Include(u => u.Identity)
                     .FirstOrDefault(u => u.Identity.UserName == name).Id;
            return users;
        }
    }
}
