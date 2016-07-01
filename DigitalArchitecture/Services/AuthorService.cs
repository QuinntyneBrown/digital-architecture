using System;
using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Data.Entity;
using System.Linq;
using DigitalArchitecture.Models;

namespace DigitalArchitecture.Services
{
    public class AuthorService : IAuthorService
    {
        public AuthorService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this.repository = uow.Authors;
            this.cache = cacheProvider.GetCache();
        }

        public AuthorAddOrUpdateResponseDto AddOrUpdate(AuthorAddOrUpdateRequestDto request)
        {
            var entity = repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) repository.Add(entity = new Author());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new AuthorAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<AuthorDto> Get()
        {
            ICollection<AuthorDto> response = new HashSet<AuthorDto>();
            var entities = repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new AuthorDto(entity)); }    
            return response;
        }


        public AuthorDto GetById(int id)
        {
            return new AuthorDto(repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Author> repository;
        protected readonly ICache cache;
    }
}
