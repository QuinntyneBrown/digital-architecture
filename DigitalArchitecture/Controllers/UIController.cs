using DigitalArchitecture.Dtos;
using DigitalArchitecture.Services;
using DigitalArchitecture.Trace;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/ui")]
    public class UIController : ApiController
    {
        public UIController(IUIService uiService, ITraceService traceService)
        {
            _uiService = uiService;
            _traceService = traceService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(UIAddOrUpdateResponseDto))]
        public IHttpActionResult Add(UIAddOrUpdateRequestDto dto) { return Ok(_uiService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(UIAddOrUpdateResponseDto))]
        public IHttpActionResult Update(UIAddOrUpdateRequestDto dto) { return Ok(_uiService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<UIDto>))]
        public IHttpActionResult Get() { return Ok(_uiService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(UIDto))]
        public IHttpActionResult GetById(int id) { return Ok(_uiService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_uiService.Remove(id)); }

        protected readonly IUIService _uiService;
        protected readonly ITraceService _traceService;
    }
}
