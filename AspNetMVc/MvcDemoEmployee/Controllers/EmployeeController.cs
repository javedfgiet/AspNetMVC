using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemoEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer ebl=new EmployeeBusinessLayer();
            List<Employee> employees=ebl.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}