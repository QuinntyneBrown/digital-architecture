using System;
using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Data.Entity;
using System.Linq;
using DigitalArchitecture.Models;

namespace DigitalArchitecture.Services
{
    public class TagService : ITagService
    {
        public TagService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Tags;
            this.cache = cacheProvider.GetCache();
        }

        public TagAddOrUpdateResponseDto AddOrUpdate(TagAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) repository.Add(entity = new Tag());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new TagAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<TagDto> Get()
        {
            ICollection<TagDto> response = new HashSet<TagDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new TagDto(entity)); }    
            return response;
        }


        public TagDto GetById(int id)
        {
            return new TagDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Tag> repository;
        protected readonly ICache cache;
    }
}
