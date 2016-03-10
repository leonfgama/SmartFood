using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Model
{
    public class Order : ModelBase
    {
        public int BoardId { get; set; }
        public string Location { get; set; }
        public virtual List<ProductOrder> Products { get; set; }        
    }
}
