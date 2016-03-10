using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Model
{
    public class Client : ModelBase
    {
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
