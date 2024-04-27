using Demo.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        // Signature For ProPerty For Each and Every Repository Interface

        public IEmployeeRepository EmployeeRepository { get; set; }
        Task<int> CompleteAsync();

        void Dispose();
    }
}
