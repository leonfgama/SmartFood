using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class FormHeader
    {
        public FormHeader()
        {

        }

        public FormHeader(string title, string subTitle, bool hasWizard = false, List<WizardItem> wizard = null)
        {
            this.Title = title;
            this.SubTitle = subTitle;
            this.HasWizard = hasWizard;
            this.Wizard = wizard;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool HasWizard { get; set; }
        public List<WizardItem> Wizard { get; set; }
        public List<BreadCrumb> BreadCrumb { get; set; }
    }
}
