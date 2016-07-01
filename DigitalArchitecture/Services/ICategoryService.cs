using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface ICategoryService
    {
        CategoryAddOrUpdateResponseDto AddOrUpdate(CategoryAddOrUpdateRequestDto request);
        ICollection<CategoryDto> Get();
        CategoryDto GetById(int id);
        dynamic Remove(int id);
    }
}
