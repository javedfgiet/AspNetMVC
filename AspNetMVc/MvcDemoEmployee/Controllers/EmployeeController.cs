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
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            List<Employee> employees = ebl.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                ebl.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}