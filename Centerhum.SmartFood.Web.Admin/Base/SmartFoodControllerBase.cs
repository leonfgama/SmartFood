using Centerhum.SmartFood.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Centerhum.SmartFood.Web.Admin.Base
{
    public class SmartFoodControllerBase : Controller
    {
        private ClientHub _client;
        public ClientHub Client 
        { 
            get
            {
                if (_client == null)
                {
                    _client = new ClientHub();
                }

                return _client;
            }
        }
    }
}