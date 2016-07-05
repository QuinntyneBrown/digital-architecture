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
            this._repository = uow.Authors;
            this.cache = cacheProvider.GetCache();
        }

        public AuthorAddOrUpdateResponseDto AddOrUpdate(AuthorAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Author());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new AuthorAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<AuthorDto> Get()
        {
            ICollection<AuthorDto> response = new HashSet<AuthorDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new AuthorDto(entity)); }    
            return response;
        }


        public AuthorDto GetById(int id)
        {
            return new AuthorDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public IQueryable<Author> GetAll() => _repository.GetAll();

        protected readonly IUow uow;
        protected readonly IRepository<Author> _repository;
        protected readonly ICache cache;
    }
}
