using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RestfulSecurity.Filters
{
    public class EnforceHttpsFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    ReasonPhrase = "HTTPS is required"
                };
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}