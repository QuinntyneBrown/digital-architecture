using System.Web.Http;
using DigitalArchitecture.Services;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/performance")]
    public class PerformanceController : ApiController
    {
        public PerformanceController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            return Ok(_performanceService.Get());
        }

        protected readonly IPerformanceService _performanceService;
    }
}
