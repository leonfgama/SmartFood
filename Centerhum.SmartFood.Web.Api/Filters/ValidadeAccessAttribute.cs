using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Centerhum.SmartFood.Web.Api.Filters
{
    public class ValidadeAccessAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }
}