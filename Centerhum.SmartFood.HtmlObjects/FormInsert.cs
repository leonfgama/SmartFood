using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Enum;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class FormInsert
    {
        public FormInsert()
        {
            this.SaveButtonLabel = "Salvar";
            this.FromBody = true;
        }

        // Principal Properties
        public string Title { get; set; }
        public string FormId { get; set; }
        public bool CustomValidate { get; set; }
        public bool IsAjax { get; set; }
        public string ActionToPost { get; set; }
        public ReturnObject SuccessMessage { get; set; }
        public ReturnObject ErrorMessage { get; set; }
        public List<FieldItem> Fields { get; set; }
        public string SaveButtonLabel { get; set; }
        public bool FromBody { get; set; }



        // Specific Properties
        public bool RedirectAfterSuccess { get; set; }
        public string UrlRedirect { get; set; }
    }
}
