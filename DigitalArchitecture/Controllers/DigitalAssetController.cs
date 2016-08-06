using DigitalArchitecture.Data;
using DigitalArchitecture.Dtos;
using DigitalArchitecture.Models;
using DigitalArchitecture.Services;
using DigitalArchitecture.Trace;
using DigitalArchitecture.UploadHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;
using static System.Drawing.Image;
using static System.Drawing.Imaging.ImageFormat;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/digitalasset")]
    public class DigitalAssetController : ApiController
    {
        public DigitalAssetController(ICacheProvider cacheProvider, IDigialAssetService digitalAssetService, IUow uow, ITraceService traceService)
        {
            _digitalAssetService = digitalAssetService;
            _uow = uow;
            _repository = uow.DigitalAssets;
            _cache = cacheProvider.GetCache();
            _traceService = traceService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(DigitalAddOrUpdateResponseDto))]
        public IHttpActionResult Add(DigitalAssetAddOrUpdateRequestDto dto) { return Ok(_digitalAssetService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(DigitalAddOrUpdateResponseDto))]
        public IHttpActionResult Update(DigitalAssetAddOrUpdateRequestDto dto) { return Ok(_digitalAssetService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<DigitalAssetDto>))]
        public IHttpActionResult Get() { return Ok(_digitalAssetService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(DigitalAssetDto))]
        public IHttpActionResult GetById(int id) { return Ok(_digitalAssetService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_digitalAssetService.Remove(id)); }

        [AllowAnonymous]
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(HttpRequestMessage request)
        {

            var photos = new List<DigitalAsset>();
            try
            {
                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                NameValueCollection formData = provider.FormData;
                IList<HttpContent> files = provider.Files;

                foreach (var file in files)
                {
                    var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
                        .Replace("&", "and")).Name;
                    Stream stream = await file.ReadAsStreamAsync();
                    var bytes = StreamHelper.ReadToEnd(stream);
                    var photo = new DigitalAsset();
                    photo.FileName = filename;
                    photo.Bytes = bytes;
                    photo.ContentType = System.Convert.ToString(file.Headers.ContentType);
                    _repository.Add(photo);
                    photos.Add(photo);
                }

                _uow.SaveChanges();
            }
            catch (Exception exception)
            {
                var e = exception;
            }

            return Request.CreateResponse(HttpStatusCode.OK, new DigitalAssetUploadResponseDto(photos));
        }

        [Route("serve")]
        [HttpGet]
        [AllowAnonymous]
        [CacheOutput(ClientTimeSpan = 0, ServerTimeSpan = 0)]
        public HttpResponseMessage Serve([FromUri]Guid uniqueId, int? height = null)
        {
            DigitalAsset photo = _cache.FromCacheOrService(() => _repository.GetAll().FirstOrDefault(x => x.UniqueId == uniqueId), uniqueId.ToString());
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            if (photo == null)
                return result;
            var memoryStream = new System.IO.MemoryStream(photo.Bytes);
            System.Drawing.Image fullsizeImage = FromStream(memoryStream);
            height = height.HasValue ? height : fullsizeImage.Height;
            var ratio = (float)height.Value / (float)fullsizeImage.Height;
            var width = fullsizeImage.Width * ratio;
            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage((int)width, height.Value, null, IntPtr.Zero);
            var myResult = new System.IO.MemoryStream();
            newImage.Save(myResult, fullsizeImage.RawFormat);
            result.Content = new ByteArrayContent(myResult.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(photo.ContentType);
            return result;
        }

        protected readonly IDigialAssetService _digitalAssetService;
        protected readonly ITraceService _traceService;
        protected readonly IRepository<DigitalAsset> _repository;
        protected readonly IUow _uow;
        protected readonly ICache _cache;


    }
}
