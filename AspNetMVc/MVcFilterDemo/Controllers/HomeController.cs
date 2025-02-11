using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVcFilterDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            //return View();
            throw new Exception("SomeThing wentWrong");
        }
        [ChildActionOnly]
        public ActionResult Countries(List<string> countrtData)
        {
            return View(countrtData);
        }
        public ActionResult NonSecureMethod()
        {
            return View();
        }

        [Authorize]
        public ActionResult SecureMethod()
        {
            return View();
        }
    }
}