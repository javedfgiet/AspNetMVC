using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{

        //    return View();
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 1,
                Name = "John",
                Gender = "Male",
                City = "London"

            };
            return View(employee);
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