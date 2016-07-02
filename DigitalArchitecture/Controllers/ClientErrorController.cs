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
        public ClientErrorController()
        {
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage ReportClientError(ClientError clientError)
        {
            TraceService.Diagnostics.Error(new Exception(clientError.Message), TracingEvents.ClientError.Message, clientError.Message, clientError.StackTrace);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
