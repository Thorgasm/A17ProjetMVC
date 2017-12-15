using A17ProjetMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace A17ProjetMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ApplicationDbContext>(new DbInitializer());
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session["Culture"] == null)
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            /*string id = User.Identity.GetUserId();
                            using (ApplicationDbContext context = new ApplicationDbContext())
                            {
                                ApplicationUser user = context.Users.FirstOrDefault(u => u.Id.Equals(id));
                                if (user != null)
                                {
                                    string l = user.Language;
                                    Session["Culture"] = new CultureInfo(l.Equals("English") || l.Equals("Anglais") ? "en-US" : "fr-CA");
                                }
                                else
                                    HttpContext.Current.Session["Culture"] = new CultureInfo("en-US");
                            }*/
                            Session["Culture"] = new CultureInfo(Thread.CurrentThread.CurrentCulture.Parent.Name.Equals("en") ? "en" : "fr");
                        }

                        else
                        {
                            HttpContext.Current.Session["Culture"] = new CultureInfo("en-US");
                        }
                    }

                    Thread.CurrentThread.CurrentUICulture = (CultureInfo)HttpContext.Current.Session["Culture"];
                    Thread.CurrentThread.CurrentCulture = (CultureInfo)HttpContext.Current.Session["Culture"];
                }
            }
        }
    
    }
}
