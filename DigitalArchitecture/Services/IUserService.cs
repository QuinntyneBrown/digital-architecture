using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IUserService
    {
        UserAddOrUpdateResponseDto AddOrUpdate(UserAddOrUpdateRequestDto request);
        ICollection<UserDto> Get();
        UserDto GetById(int id);
        dynamic Remove(int id);
    }
}
