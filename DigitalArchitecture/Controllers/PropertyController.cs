using DigitalArchitecture.Dtos;
using DigitalArchitecture.Services;
using DigitalArchitecture.Trace;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/property")]
    public class PropertyController : ApiController
    {
        public PropertyController(IPropertyService propertyService, ITraceService traceService)
        {
            _propertyService = propertyService;
            _traceService = traceService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(PropertyAddOrUpdateResponseDto))]
        public IHttpActionResult Add(PropertyAddOrUpdateRequestDto dto) { return Ok(_propertyService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(PropertyAddOrUpdateResponseDto))]
        public IHttpActionResult Update(PropertyAddOrUpdateRequestDto dto) { return Ok(_propertyService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<PropertyDto>))]
        public IHttpActionResult Get() { return Ok(_propertyService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(PropertyDto))]
        public IHttpActionResult GetById(int id) { return Ok(_propertyService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_propertyService.Remove(id)); }

        protected readonly IPropertyService _propertyService;
        protected readonly ITraceService _traceService;

    }
}
