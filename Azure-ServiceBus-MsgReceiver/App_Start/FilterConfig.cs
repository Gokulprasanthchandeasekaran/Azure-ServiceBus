using System.Web;
using System.Web.Mvc;

namespace Azure_ServiceBus_MsgReceiver
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
