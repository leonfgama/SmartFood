using Centerhum.SmartFood.HtmlObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centerhum.SmartFood.Web.Admin
{
    public class HomeViewsConfig : HtmlObjectsBase
    {
        private static HomeViewsConfig _instance;
        public static HomeViewsConfig Instance 
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new HomeViewsConfig();
                }

                return _instance;
            } 
        }

        public FrontPage Index()
        {
            base.FormHeader = new FormHeader("Home", "Descrição 123...");
            return base.FrontPage;
        }

    }
}
