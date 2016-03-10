using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class FrontPage
    {
        public FormHeader FormHeader { get; set; }
        public FormInsert FormInsert { get; set; }
        public FormUpdate FormUpdate { get; set; }
        public FormList FormList { get; set; }
        public FormDetail FormDetail { get; set; }

        public object ModelValue { get; set; }
    }
}
