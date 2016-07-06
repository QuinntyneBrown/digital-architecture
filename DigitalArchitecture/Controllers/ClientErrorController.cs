using DigitalArchitecture.Models;
using DigitalArchitecture.Trace;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigitalArchitecture.Controllers
{
    [Authorize]
    [RoutePrefix("api/clientError")]
    public class ClientErrorController : ApiController
    {
        public ClientErrorController(ITraceService traceService)
        {
            _traceService = traceService;
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage ReportClientError(ClientError clientError)
        {
            _traceService.Diagnostics.Error(new Exception(clientError.Message), TracingEvents.ClientError.Message, clientError.Message, clientError.StackTrace);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        protected readonly ITraceService _traceService;
    }
}
