using ITI_MVC.Models;
using ITI_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_MVC.Controllers
{
	public class ValidationController : Controller
	{
		private Company22Context context;
        public ValidationController()
        {
            context = new Company22Context();
        }
        [HttpGet]
		public IActionResult Add()
		{
			EmployeesVM emp = new EmployeesVM()
			{
				Offices = new SelectList(context.office,"Id","Name")
			};
			return View(emp);
		}
		[HttpPost]
		public IActionResult Add(EmployeesVM emp) 
		{
			if(ModelState.IsValid)
			{
				Employee employee = new Employee()
				{
					Name=emp.Name,
					Adress=emp.Adress,
					department=emp.department,
					Salary =emp.Salary,
					Email =emp.Email,
					Password =emp.Password,
					Office_Id =emp.Office_Id
				};
				context.employees.Add(employee);
				context.SaveChanges();

				return RedirectToAction("inforamtion", "Employees");
			}
			emp.Offices = new SelectList(context.office, "Id", "Name");
			return View(emp);

		}
	}
}
