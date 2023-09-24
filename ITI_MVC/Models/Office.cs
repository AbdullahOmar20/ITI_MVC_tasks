using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.Models
{
    public class Office
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<Employee>? employees { get; set; } = new List<Employee>();

    }
}
