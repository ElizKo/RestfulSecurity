using RestfulSecurity.Database;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestfulSecurity.Controllers
{
    // [EnableCors("*", "*", "*", "DataServiceVersion, MaxDataServiceVersion")]
    public class BaseController : ApiController
    {
        // Instance of EF DataContext to access the database
        protected DataContext db = new DataContext();

        // This is required in order to enable CORS for Cross-Domain Ajax Requests
        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}