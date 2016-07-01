using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IPhotoService
    {
        PhotoAddOrUpdateResponseDto AddOrUpdate(PhotoAddOrUpdateRequestDto request);
        ICollection<PhotoDto> Get();
        PhotoDto GetById(int id);
        dynamic Remove(int id);
    }
}
