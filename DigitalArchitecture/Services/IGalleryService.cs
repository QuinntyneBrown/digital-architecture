using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IGalleryService
    {
        GalleryAddOrUpdateResponseDto AddOrUpdate(GalleryAddOrUpdateRequestDto request);
        ICollection<GalleryDto> Get();
        GalleryDto GetById(int id);
        dynamic Remove(int id);
    }
}
