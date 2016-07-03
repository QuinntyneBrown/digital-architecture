using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IUserService
    {
        RegistrationResponseDto Register(RegistrationRequestDto request);
        CurrentUserResponseDto Current(string username);
        UserAddOrUpdateResponseDto AddOrUpdate(UserAddOrUpdateRequestDto request);
        ICollection<UserDto> Get();
        UserDto GetById(int id);
        dynamic Remove(int id);
    }
}
