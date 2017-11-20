using System.Web;
using System.Web.Mvc;

namespace INF2._2_Project_HaarlemFestival
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
