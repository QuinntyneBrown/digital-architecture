using DigitalArchitecture.Dtos;
using DigitalArchitecture.Services;
using DigitalArchitecture.Trace;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        public RoleController(IRoleService roleService, ITraceService traceService)
        {
            _roleService = roleService;
            _traceService = traceService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(RoleAddOrUpdateResponseDto))]
        public IHttpActionResult Add(RoleAddOrUpdateRequestDto dto) { return Ok(_roleService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(RoleAddOrUpdateResponseDto))]
        public IHttpActionResult Update(RoleAddOrUpdateRequestDto dto) { return Ok(_roleService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<RoleDto>))]
        public IHttpActionResult Get() { return Ok(_roleService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(RoleDto))]
        public IHttpActionResult GetById(int id) { return Ok(_roleService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_roleService.Remove(id)); }

        protected readonly IRoleService _roleService;
        protected readonly ITraceService _traceService;

    }
}
