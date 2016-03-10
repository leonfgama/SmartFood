using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class Options
    {
        public bool CreateDeleteButton { get; set; }
        public bool CreateUpdateButton { get; set; }
        public bool CreateDetailButton { get; set; }

        public string ActionNameDelete { get; set; }
        public string ActionNameUpdate { get; set; }
        public string ActionNameDetail { get; set; }

        public List<GridButton> GridButtons { get; set; }
    }
}
