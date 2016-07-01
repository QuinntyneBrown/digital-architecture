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
    }
}
