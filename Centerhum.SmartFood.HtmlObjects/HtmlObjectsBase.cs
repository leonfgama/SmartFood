using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public abstract class HtmlObjectsBase
    {

        private FrontPage _frontPage;
        protected FrontPage FrontPage
        {
            get
            {
                if (_frontPage == null)
                {
                    _frontPage = new FrontPage();
                }

                _frontPage.FormHeader = this.FormHeader;
                _frontPage.FormDetail = this.FormDetail;
                _frontPage.FormInsert = this.FormInsert;
                _frontPage.FormList   = this.FormList;
                _frontPage.FormUpdate = this.FormUpdate;
                _frontPage.ModelValue = this.ModelValue;


                return _frontPage;
            }
            set
            {
                _frontPage = value;
            }
        }

        protected FormHeader FormHeader { get; set; }
        protected FormInsert FormInsert { get; set; }
        protected FormUpdate FormUpdate { get; set; }
        protected FormList FormList { get; set; }
        protected FormDetail FormDetail { get; set; }

        protected object ModelValue { get; set; }

        protected void MakeFrontPage()
        {
            var frontPage = new FrontPage();
            frontPage.FormHeader = this.FormHeader;
            frontPage.FormDetail = this.FormDetail;
            frontPage.FormInsert = this.FormInsert;
            frontPage.FormList = this.FormList;
            frontPage.FormUpdate = this.FormUpdate;
            frontPage.ModelValue = this.ModelValue;
            this.FrontPage = frontPage;
        }
    }
}
