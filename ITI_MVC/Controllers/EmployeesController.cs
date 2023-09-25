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
            ViewBag.Office = context.office.ToList();
            return View();
        }
        public IActionResult Insert(Employee emp) 
        {
            context.employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("information");
        }
        public IActionResult Edit(int id )
        {
            Employee emp = context.employees.Where(i=>i.Id == id).SingleOrDefault();
			if (emp == null)
			{
				return Content("Error");
			}
			ViewBag.Office = context.office.ToList();
            return View(emp);
        }
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
            Emp_Project emp_pro = context.emp_Projs.SingleOrDefault(i => i.Emp_Id == id);
            if(emp_pro != null) 
            {
				context.emp_Projs.Remove(emp_pro);
			}
            
            context.employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("information");
        }

    }
}
