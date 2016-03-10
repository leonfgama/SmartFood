using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.Model
{
    public class Location : ModelBase
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public int ApNumber { get; set; }
        public string Complement { get; set; }
    }
}
