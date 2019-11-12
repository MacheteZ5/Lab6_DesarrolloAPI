using System.Web;
using System.Web.Mvc;

namespace LAB6_1229918_1251518_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
