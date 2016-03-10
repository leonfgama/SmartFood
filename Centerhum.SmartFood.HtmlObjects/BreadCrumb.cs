using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class BreadCrumb
    {
        public BreadCrumb()
        {

        }

        public BreadCrumb(string title, string url)
        {
            this.Title = title;
            this.Url = url;
        }

        public BreadCrumb(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}