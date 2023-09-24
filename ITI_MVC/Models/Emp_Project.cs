using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC.Models
{
    public class Emp_Project
    {
        [ForeignKey("employee")]
        public int Emp_Id { get; set; }
        [ForeignKey("project")]
        public int Project_Id { get; set;}
        public virtual Employee? employee { get; set;}
        public virtual Project? project { get; set;}
        public int? WorkingHours { get;set;}
    }
}
