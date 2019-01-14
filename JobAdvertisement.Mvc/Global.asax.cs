using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using JobAdvertisement.DataAccess.Concrete.Context;

namespace JobAdvertisement.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Application_Start()
        {
            Database.SetInitializer<JobAdContext>(new DropCreateDatabaseIfModelChanges<JobAdContext>());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //}
    }
}
