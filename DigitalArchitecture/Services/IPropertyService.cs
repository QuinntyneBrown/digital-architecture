using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IPropertyService
    {
        PropertyAddOrUpdateResponseDto AddOrUpdate(PropertyAddOrUpdateRequestDto request);
        ICollection<PropertyDto> Get();
        PropertyDto GetById(int id);
        dynamic Remove(int id);
    }
}
