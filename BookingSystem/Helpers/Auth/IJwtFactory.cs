using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingSystem.Helpers.Auth
{
    public interface IJwtFactory
    {
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
    }
}
