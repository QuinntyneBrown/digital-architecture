using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IDigialAssetService
    {
        DigitalAddOrUpdateResponseDto AddOrUpdate(DigitalAssetAddOrUpdateRequestDto request);
        ICollection<DigitalAssetDto> Get();
        DigitalAssetDto GetById(int id);
        dynamic Remove(int id);
    }
}
