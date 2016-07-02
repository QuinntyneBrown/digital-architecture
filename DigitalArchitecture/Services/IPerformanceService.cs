using DigitalArchitecture.Dtos;
using System.Collections.Generic;

namespace DigitalArchitecture.Services
{
    public interface IPerformanceService
    {
        ICollection<PerformanceDto> Get();
    }
}
