using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface ISectionService
    {
        SectionAddOrUpdateResponseDto AddOrUpdate(SectionAddOrUpdateRequestDto request);
        ICollection<SectionDto> Get();
        SectionDto GetById(int id);
        dynamic Remove(int id);
    }
}
