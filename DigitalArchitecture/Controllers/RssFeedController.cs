using DigitalArchitecture.Services;
using System.ServiceModel.Syndication;
using System.Web.Http;

namespace DigitalArchitecture.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/rss")]
    public class RssFeedController: ApiController
    {
        public RssFeedController(IRssFeedService rssFeedService)
        {
            _rssFeedService = rssFeedService;
        }

        public Rss20FeedFormatter Get() => new Rss20FeedFormatter(_rssFeedService.Get());

        protected readonly IRssFeedService _rssFeedService;
    }
}
