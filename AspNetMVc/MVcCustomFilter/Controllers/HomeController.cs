using MVcCustomFilter.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVcCustomFilter.Controllers
{
    public class HomeController : Controller
    {
        [TrackExecutionTime]
        public string Index()
        {
            return "Index Action Invoked";
        }

        [TrackExecutionTime]
        public string Welcome()
        {
            throw new Exception("Exception occured");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}