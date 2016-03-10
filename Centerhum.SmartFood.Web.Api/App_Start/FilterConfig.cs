using System.Web;
using System.Web.Mvc;

namespace Centerhum.SmartFood.Web.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
