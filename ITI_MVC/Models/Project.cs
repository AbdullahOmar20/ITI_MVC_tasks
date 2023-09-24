using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Emp_Project>? emp_Projects { get; set; } = new List<Emp_Project>();

    }
}
