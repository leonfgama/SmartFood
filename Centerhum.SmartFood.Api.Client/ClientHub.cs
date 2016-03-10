using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Api.Client
{
    public class ClientHub
    {
        private ProductClient _product;
        public ProductClient Product { get { if (_product == null) _product = new ProductClient(); return _product; } }
    }
}
