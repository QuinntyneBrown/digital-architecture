using System;
using System.Collections.Generic;
using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using System.Data.Entity;
using System.Linq;
using DigitalArchitecture.Models;

namespace DigitalArchitecture.Services
{
    public class DigitalAssetService : IDigialAssetService
    {
        public DigitalAssetService(IUow uow, ICacheProvider cacheProvider)
        {
            this.uow = uow;
            this._repository = uow.DigitalAssets;
            this.cache = cacheProvider.GetCache();
        }

        public DigitalAddOrUpdateResponseDto AddOrUpdate(DigitalAssetAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new DigitalAsset());
            entity.Name = request.Name;
            uow.SaveChanges();
            return new DigitalAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            uow.SaveChanges();
            return id;
        }

        public ICollection<DigitalAssetDto> Get()
        {
            ICollection<DigitalAssetDto> response = new HashSet<DigitalAssetDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new DigitalAssetDto(entity)); }    
            return response;
        }


        public DigitalAssetDto GetById(int id)
        {
            return new DigitalAssetDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow uow;
        protected readonly IRepository<DigitalAsset> _repository;
        protected readonly ICache cache;
    }
}
