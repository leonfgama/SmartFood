using Centerhum.SmartFood.Api.Client.Base;
using Centerhum.SmartFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Api.Client
{
    public class ProductClient : ApiClientBase
    {
        public Product GetAllProducts()
        {
            return CallApi<Product>("Product", "GetAll", HttpMethods.GET);
        }
    }
}
