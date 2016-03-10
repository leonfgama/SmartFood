using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class FormDetail
    {
        public string Title { get; set; }
        public List<HeaderColumn> HeaderColumn { get; set; }
        public DataSet DataSetValue { get; set; }
        public object ObjectValue { get; set; }
        public List<FormDetail> Sections { get; set; }
    }
}
