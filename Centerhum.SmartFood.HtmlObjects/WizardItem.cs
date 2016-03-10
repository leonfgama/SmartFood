using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class WizardItem
    {
        public WizardItem()
        {

        }

        public WizardItem(int index, string description, string url = "#", bool isCurrent = false, bool hasSuccess = false)
        {
            this.Index = index;
            this.Description = description;
            this.Url = url;
            this.IsCurrent = isCurrent;
            this.HasSuccess = hasSuccess;
        }


        public int Index { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsCurrent { get; set; }
        public bool HasSuccess { get; set; }
    }
}
