using Demo.BLL.Interfaces;

namespace Employee_Addition_Form.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        int Complete();
    }
}
