using System;
using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Data.Entity;
using System.Linq;
using DigitalArchitecture.Models;

namespace DigitalArchitecture.Services
{
    public class PhotoService : IPhotoService
    {
        public PhotoService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this._repository = uow.Photos;
            this.cache = cacheProvider.GetCache();
        }

        public PhotoAddOrUpdateResponseDto AddOrUpdate(PhotoAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Photo());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new PhotoAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<PhotoDto> Get()
        {
            ICollection<PhotoDto> response = new HashSet<PhotoDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new PhotoDto(entity)); }    
            return response;
        }


        public PhotoDto GetById(int id)
        {
            return new PhotoDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<Photo> _repository;
        protected readonly ICache cache;
    }
}
