using System.Web;
using System.Web.Mvc;

namespace TP_ApiWeb_Catalogo_Grupo25B
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
