using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ITI_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private Company22Context context;
        public EmployeesController()
        {
            context = new Company22Context();
        }
        public IActionResult Information()
        {
            List<Employee> employees = context.employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee = context.employees.Where(e => e.Id == id).SingleOrDefault();
            if(employee == null)
            {
                return Content("Error");
            }
            return View(employee);
        }
        public IActionResult Add() 
        { 
            return View();
        }
        public IActionResult Insert(Employee emp) 
        {
            context.employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("information");
        }

    }
}
