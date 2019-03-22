﻿using RestaurantPaymentSystem.DB;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RestaurantPaymentSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<EFRestaurantPaymentSystemDB>(new DropCreateDatabaseIfModelChanges<EFRestaurantPaymentSystemDB>());
        }
    }
}
