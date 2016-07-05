using System;
using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Data.Entity;
using System.Linq;
using DigitalArchitecture.Models;

namespace DigitalArchitecture.Services
{
    public class SectionService : ISectionService
    {
        public SectionService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this._repository = uow.Sections;
            this.cache = cacheProvider.GetCache();
        }

        public SectionAddOrUpdateResponseDto AddOrUpdate(SectionAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Section());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new SectionAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<SectionDto> Get()
        {
            ICollection<SectionDto> response = new HashSet<SectionDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SectionDto(entity)); }    
            return response;
        }


        public SectionDto GetById(int id)
        {
            return new SectionDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Section> _repository;
        protected readonly ICache cache;
    }
}
