using System;
using System.Linq;
using System.ServiceModel.Syndication;
using static DigitalArchitecture.Common.Constants;

namespace DigitalArchitecture.Services
{
    public class RssFeedService : IRssFeedService
    {
        public RssFeedService(ICacheProvider cacheProvider, IArticleService articleService)
        {
            _cache = cacheProvider.GetCache();
            _articleService = articleService;
        }

        public SyndicationFeed Get() => new SyndicationFeed(BlogTitle, BlogDescription, new Uri(BlogUrl))
        {
            Items = _articleService.Get().Select(x => new SyndicationItem(
                x.Headline,
                x.Excerpt,
                new Uri(x.Url),
                $"{x.Id}",
                x.DateModified.Value)).ToList()
        };

        protected readonly ICache _cache;
        protected readonly IArticleService _articleService;
    }
}
