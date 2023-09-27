using ITI_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC.Controllers
{
	public class OfficeController : Controller
	{
		private Company22Context context;
		public OfficeController()
		{
			context = new Company22Context();
		}
		public IActionResult Information()
		{
			List<Office> office = context.office.ToList();
			return View(office);
		}
        public IActionResult Details(int id)
        {
            Office office = context.office.Where(e => e.Id == id).SingleOrDefault();
            if (office == null)
            {
                return Content("Error");
            }

            return View(office);
        }
		[HttpGet]
        public IActionResult Add()
        {
            return View();
        }
		[HttpPost]
        public IActionResult Insert(Office office)
        {
            context.office.Add(office);
            context.SaveChanges();
            return RedirectToAction("information");
        }
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Office office = context.office.Where(i => i.Id == id).SingleOrDefault();
			if (office == null)
			{
				return Content("Error");
			}
			
			return View(office);
		}
		[HttpPost]
		public IActionResult EditONDB(Office office)
		{
			Office off = context.office.SingleOrDefault(i => i.Id == office.Id);
			off.Name = office.Name;
			off.Location = office.Location;
			
			context.SaveChanges();
			return RedirectToAction("Information");
		}
		public IActionResult Delete(int id)
		{
			Office office= context.office.SingleOrDefault(i => i.Id == id);
			var emp = context.employees.Where(i => i.Office_Id == id);
            if (emp != null)
            {
                foreach(var item in emp)
				{
					item.Office_Id = null;
				}
            }
            context.office.Remove(office);
			context.SaveChanges();
			return RedirectToAction("information");
		}
	}
}
