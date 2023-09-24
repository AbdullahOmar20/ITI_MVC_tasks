using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public  string?  Name { get; set; }
        public string? Adress { get; set; }
        public int? Salary { get; set; }

        public string? department { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [ForeignKey("office")]
        public int? Office_Id { get; set; }
        public virtual Office office { get; set; }
        public List<Emp_Project>? emp_Projects { get; set; } = new List<Emp_Project>();
    }
}
