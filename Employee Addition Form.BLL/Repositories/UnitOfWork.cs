using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Employee_Addition_Form.BLL.Interfaces;
using Employee_Addition_Form.DAL.Context;

namespace Employee_Addition_Form.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEmployeeRepository EmployeeRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
