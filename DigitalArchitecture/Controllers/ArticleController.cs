using DigitalArchitecture.Dtos;
using DigitalArchitecture.Services;
using DigitalArchitecture.Trace;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        public ArticleController(IArticleService articleService, ITraceService traceService)
        {
            _articleService = articleService;
            _traceService = traceService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ArticleAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ArticleAddOrUpdateRequestDto dto) { return Ok(_articleService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ArticleAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ArticleAddOrUpdateRequestDto dto) { return Ok(_articleService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ArticleDto>))]
        public IHttpActionResult Get() { return Ok(_articleService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ArticleDto))]
        public IHttpActionResult GetById(int id) { return Ok(_articleService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_articleService.Remove(id)); }

        protected readonly IArticleService _articleService;
        protected readonly ITraceService _traceService;
    }
}
