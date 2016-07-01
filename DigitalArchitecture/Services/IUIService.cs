using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IUIService
    {
        UIAddOrUpdateResponseDto AddOrUpdate(UIAddOrUpdateRequestDto request);
        ICollection<UIDto> Get();
        UIDto GetById(int id);
        dynamic Remove(int id);
    }
}
