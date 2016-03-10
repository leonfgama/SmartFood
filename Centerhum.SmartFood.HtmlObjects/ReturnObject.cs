using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Enum;
namespace Centerhum.SmartFood.HtmlObjects
{
    public class ReturnObject
    {
        private string _urlRedirect;

        public string UrlRedirect
        {
            get { return string.IsNullOrWhiteSpace(_urlRedirect) ? string.Empty : _urlRedirect; }
            set { _urlRedirect = value; }
        }

        public string Message { get; set; }


        public ReturnType Status { get; set; }
        public object ObjectResponse { get; set; }
    }
}