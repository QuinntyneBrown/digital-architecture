using DigitalArchitecture.Data;
using System.Web.Http;
using System.Linq;
using DigitalArchitecture.Dtos;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/performance")]
    public class PerformanceController : ApiController
    {
        public PerformanceController(IUow uow)
        {
            _repository = uow.Performance;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAll().ToList().Select(x=> new PerformanceDto(x)).ToList());
        }

        protected readonly IRepository<Models.Performance> _repository;
    }
}
