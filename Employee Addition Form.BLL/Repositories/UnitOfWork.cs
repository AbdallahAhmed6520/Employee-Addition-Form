using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Employee_Addition_Form.BLL.Interfaces;
using Employee_Addition_Form.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form.BLL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _dbcontext;

        public IEmployeeRepository EmployeeRepository { get; set; }
        public UnitOfWork(AppDbContext dbcontext)
        {
            EmployeeRepository = new EmployeeRepository(dbcontext);
            _dbcontext = dbcontext;
        }

        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
