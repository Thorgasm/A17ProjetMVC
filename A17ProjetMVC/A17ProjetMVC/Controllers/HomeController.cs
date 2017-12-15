using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace A17ProjetMVC.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("IndexFrEn")]
        public ActionResult IndexFrEn(string returnUrl)
        {            
            if(Thread.CurrentThread.CurrentCulture.Parent.Name == "fr")
                Session["Culture"] = new CultureInfo("en-US");
            else
                Session["Culture"] = new CultureInfo("fr-CA");

            return RedirectToLocal(returnUrl);
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}