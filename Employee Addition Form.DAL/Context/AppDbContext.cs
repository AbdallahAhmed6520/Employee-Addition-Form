using Employee_Addition_Form.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Addition_Form.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
