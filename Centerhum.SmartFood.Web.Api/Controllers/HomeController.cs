using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Centerhum.SmartFood.Web.Api.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public List<string> Teste()
        {
            return new List<string>() { "EOQ", "LAGO AQUI LAGO AI" };
        }
    }
}
