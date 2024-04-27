using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Employee_Addition_Form.BLL.Interfaces;
using Employee_Addition_Form.DAL.Context;
using System;
using System.Threading.Tasks;

namespace Employee_Addition_Form.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbcontext;

        public IEmployeeRepository EmployeeRepository { get; set; }
        public UnitOfWork(AppDbContext dbcontext)
        {
            EmployeeRepository = new EmployeeRepository(dbcontext);
            _dbcontext = dbcontext;
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
