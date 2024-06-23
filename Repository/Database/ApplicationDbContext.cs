using Employee_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Repository.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        

        //seeding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeModel>().HasData(
                new EmployeeModel
                {
                   EmployeeId = 1,
                   Empname = "Netra",
                   Department="IT",
                   Salary=25000
                }
                ); ; ;
        }
    }
}
