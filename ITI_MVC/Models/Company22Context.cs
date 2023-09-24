using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Models
{
    public class Company22Context : DbContext
    {
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Office> office { get; set; }
        public virtual DbSet<Project> projects { get; set; }
        public virtual DbSet<Emp_Project> emp_Projs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITI_G4;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp_Project>().HasKey("Emp_Id", "Project_Id");
        }
    }
}
