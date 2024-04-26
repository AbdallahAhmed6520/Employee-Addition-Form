using AutoMapper;
using Demo.BLL.Interfaces;
using Employee_Addition_Form.DAL.Entities;
using Employee_Addition_Form.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Addition_Form.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployees);
        }
    }
}
