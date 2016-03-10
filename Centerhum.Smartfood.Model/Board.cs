using Centerhum.SmartFood.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Model
{
    public class Board : ModelBase
    {
        public string Name { get; set; }
        public BoardStatusType Status { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
