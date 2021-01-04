using EveryNote.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EveryNote.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Dal da kullan�c� ad�n�n kullan�labilmesi i�in, proje aya�a kalkerken Common katman�ndaki verileri dolduruyoruz.
            App.Common = new WebCommon();

        }
    }
}
