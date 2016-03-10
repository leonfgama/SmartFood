using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class SearchParameters
    {
        private bool _customValidate;

        /// <summary>
        /// Default value is False !
        /// </summary>
        public bool CustomValidate
        {
            get { return (_customValidate == null) ? false : _customValidate; }
            set { _customValidate = value; }
        }

        public string Title { get; set; }
        public string UrlAction { get; set; }
        public string FormId { get; set; }
        public bool IsAjax { get; set; }
        public List<FieldItem> Fields { get; set; }
    }
}
