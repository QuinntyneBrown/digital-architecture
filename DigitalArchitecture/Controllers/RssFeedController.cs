using DigitalArchitecture.Services;
using DigitalArchitecture.Trace;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalArchitecture.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/rss")]
    public class RssFeedController: ApiController
    {
        public RssFeedController(IRssFeedService rssFeedService, ITraceService traceService)
        {
            _rssFeedService = rssFeedService;
            _traceService = traceService;
        }

        [Route("get")]
        [ResponseType(typeof(Rss20FeedFormatter))]
        public Rss20FeedFormatter Get() => new Rss20FeedFormatter(_rssFeedService.Get());

        protected readonly IRssFeedService _rssFeedService;
        protected readonly ITraceService _traceService;
    }
}
