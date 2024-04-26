using Demo.BLL.Interfaces;
using Employee_Addition_Form.DAL.Context;
using Employee_Addition_Form.DAL.Entities;
using System.Linq;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
