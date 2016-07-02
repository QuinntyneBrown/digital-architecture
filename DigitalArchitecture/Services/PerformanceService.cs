using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Linq;
using DigitalArchitecture.Models;

namespace DigitalArchitecture.Services
{
    public class PerformanceService : IPerformanceService
    {
        public PerformanceService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this._repository = uow.Performance;
            this.cache = cacheProvider.GetCache();
        }


        public ICollection<PerformanceDto> Get()
        {
            return _repository.GetAll().ToList().Select(x => new PerformanceDto(x)).ToList();
        }

        protected readonly IUow uow;
        protected readonly IRepository<Performance> _repository;
        protected readonly ICache cache;
    }
}
