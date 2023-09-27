using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModels
{
	public class EmployeesVM
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[StringLength(100)]
		public string? Adress { get; set; }
		[Range(3000, 10000)]
		public int? Salary { get; set; }

		public string? department { get; set; }
		public string? Email { get; set; }
		[RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z[0-9]]{8,}$")]
		public string? Password { get; set; }
		[Compare("Password")]
		public string? ConfirmPassword { get; set; }
		[Display(Name="Office")]
		public int? Office_Id { get; set; }
		[ValidateNever]
		public SelectList? Offices { get; set; }
	}
}
