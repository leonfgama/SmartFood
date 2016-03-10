using Centerhum.SmartFood.DataLayer;
using Centerhum.SmartFood.HtmlObjects;
using Centerhum.SmartFood.Model;
using Centerhum.SmartFood.Web.Admin.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Centerhum.SmartFood.Web.Admin.Controllers
{
    public class BoardController : SmartFoodControllerBase
    {
        public ActionResult CreateInsertBoardForm()
        {
            return PartialView("_CreateInsertBoardForm");
        }
    }
}