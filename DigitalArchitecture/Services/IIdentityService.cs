using DigitalArchitecture.Dtos;
using System.Collections.Generic;
using System.Security.Claims;

namespace DigitalArchitecture.Services
{
    public interface IIdentityService
    {

        TokenDto TryToRegister(RegistrationRequestDto registrationRequestDto);

        bool AuthenticateUser(string username, string password);

        ICollection<Claim> GetClaimsForUser(string username);
    }
}
