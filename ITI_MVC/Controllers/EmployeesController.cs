using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet]
        public IActionResult Add() 
        {
            var office = context.office.ToList();
            ViewBag.Office = new SelectList(office,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Employee emp) 
        {
            context.employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("information");
        }
        [HttpGet]
        public IActionResult Edit(int id )
        {
            Employee emp = context.employees.Where(i=>i.Id == id).SingleOrDefault();
			if (emp == null)
			{
				return Content("Error");
			}
			var office = context.office.ToList();
            ViewBag.Office= new SelectList(office,"Id","Name");
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditONDB(Employee emp)
        {
            Employee e = context.employees.SingleOrDefault(i => i.Id == emp.Id);
            e.Name = emp.Name;
            e.Salary= emp.Salary;
            e.Adress= emp.Adress;
            e.department = emp.department;
            e.Office_Id= emp.Office_Id;
            context.SaveChanges();
            return RedirectToAction("information");
        }
        public IActionResult Delete(int id)
        {
            Employee emp = context.employees.SingleOrDefault(i=>i.Id == id);
            var emp_pro = context.emp_Projs.Where(i => i.Emp_Id == id);
            if(emp_pro != null) 
            {
				foreach (var p in emp_pro)
                {
                    context.emp_Projs.Remove(p);
                }
			}
            
            context.employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("information");
        }

    }
}
