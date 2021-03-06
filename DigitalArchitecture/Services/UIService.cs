using System;
using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Data.Entity;
using System.Linq;
using DigitalArchitecture.Models;
using static DigitalArchitecture.Services.PropertyHelper;

namespace DigitalArchitecture.Services
{
    public class UIService : IUIService
    {
        public UIService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.UIs;
            _cache = cacheProvider.GetCache();
        }

        public UIAddOrUpdateResponseDto AddOrUpdate(UIAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new UI());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new UIAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<UIDto> Get()
        {
            ICollection<UIDto> response = new HashSet<UIDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new UIDto(entity)); }    
            return response;
        }

        public UIDto GetById(int id)
        {
            return new UIDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }
        
        public IQueryable<UI> GetAll() => GetAll()
            .Include(x => x.Sections)
            .Include(x => x.Properties)
            .Include("UIProperties.Property")
            .Include("Sections.Section");

        protected readonly IUow _uow;
        protected readonly IRepository<UI> _repository;
        protected readonly ICache _cache;
    }
}
