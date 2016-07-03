using DigitalArchitecture.Models;

namespace DigitalArchitecture.Dtos
{
    public class CurrentUserResponseDto: UserDto
    {
        public CurrentUserResponseDto(User entity)
            : base(entity)
        {

        }

        public CurrentUserResponseDto()
        {

        }
    }
}