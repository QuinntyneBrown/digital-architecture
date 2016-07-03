using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface ITagService
    {
        TagAddOrUpdateResponseDto AddOrUpdate(TagAddOrUpdateRequestDto request);
        ICollection<TagDto> Get();
        TagDto GetById(int id);
        dynamic Remove(int id);
    }
}
