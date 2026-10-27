using System.Web;
using System.Web.Mvc;

namespace BE5_NGUYENHUUMINH
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
