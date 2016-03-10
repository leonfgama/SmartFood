using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Enum;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class HeaderColumn
    {
        // Principal Properties
        public int Order { get; set; }
        public string Label { get; set; }
        public string DataName { get; set; }
        public string StringFormat { get; set; }
        public bool IsPrimaryKey { get; set; }
        public ColumnType ColumnType { get; set; }
        public string AppendHeaderClass { get; set; }
        public string AppendValueClass { get; set; }


        #region Properties for Boolean value

        public string LabelIfTrue { get; set; }
        public string LabelIfFalse { get; set; }

        #endregion

        #region Properties for Int value

        public List<LabelForInt> LabelsForInt { get; set; }

        #endregion

        #region Properties for DateTime value



        #endregion
    }
}