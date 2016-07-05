using System.Collections.Generic;
using DigitalArchitecture.Dtos;
using DigitalArchitecture.Data;
using System.Linq;
using System.Data.Entity;
using DigitalArchitecture.Models;
using static System.DateTime;

namespace DigitalArchitecture.Services
{
    public class ArticleService : IArticleService
    {
        public ArticleService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Articles;
            _cache = cacheProvider.GetCache();
        }

        public ArticleAddOrUpdateResponseDto AddOrUpdate(ArticleAddOrUpdateRequestDto request)
        {
            var entity = GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Article());
            entity.Name = request.Name;
            entity.AuthorId = request.AuthorId;
            entity.Excerpt = request.Excerpt;
            entity.ArticleBody = request.ArticleBody;
            entity.Headline = request.Headline;
            entity.AlternativeHeadline = request.AlternativeHeadline;
            entity.Url = request.Url;

            entity.Images.Clear();

            foreach(var image in request.Image)
            {

            }

            entity.Tags.Clear();

            foreach (var tag in request.Tags)
            {

            }

            entity.Categories.Clear();

            foreach(var category in request.Categories)
            {

            }

            entity.DateModified = Now;
            entity.DatePublished = request.DatePublished;
            entity.Author = request.Author != null ? _uow.Authors.GetById(request.Author.Id) : null;

            _uow.SaveChanges();

            return new ArticleAddOrUpdateResponseDto(entity);
        }

        public ICollection<ArticleDto> Get()
        {
            ICollection<ArticleDto> response = new HashSet<ArticleDto>();
            var entities = GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new ArticleDto(entity)); }
            return response;
        }

        public ArticleDto GetById(int id)
        {
            return new ArticleDto(GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public IQueryable<Article> GetAll() => _repository.GetAll()
                .Include(x => x.Author)
                .Include(x => x.Categories)
                .Include(x => x.Tags)
                .Include(x => x.Images)
                .Include("Categories.Category")
                .Include("Tags.Tag")
                .Include("Images.Image");
        
        protected readonly IUow _uow;
        protected readonly IRepository<Models.Article> _repository;
        protected readonly ICache _cache;
    }
}
