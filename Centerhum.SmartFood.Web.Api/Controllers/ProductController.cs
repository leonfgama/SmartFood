using Centerhum.SmartFood.DataLayer;
using Centerhum.SmartFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Centerhum.SmartFood.Web.Api.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public Product GetAll()
        {
            return new ProductDataLayer().Find(1);
        }

        [HttpGet]
        public Order GetOrder()
        {
            return new OrderDataLayer().Find(1);
        }
    }
}
