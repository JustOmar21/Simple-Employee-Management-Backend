using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext() { }
        public EmpContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
