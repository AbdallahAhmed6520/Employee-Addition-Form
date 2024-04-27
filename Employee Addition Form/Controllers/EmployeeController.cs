using AutoMapper;
using Demo.BLL.Interfaces;
using Employee_Addition_Form.BLL.Interfaces;
using Employee_Addition_Form.DAL.Entities;
using Employee_Addition_Form.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Addition_Form.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);

                _unitOfWork.EmployeeRepository.Add(MappedEmployee);
                _unitOfWork.Complete(); 
                
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest(); //status code 400

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee is null)
                return NotFound();

            var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(viewName, MappedEmployee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeViewModel, [FromRoute] int id)
        {
            if (id != employeeViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);

                    _unitOfWork.EmployeeRepository.Update(MappedEmployee);
                    _unitOfWork.Complete();
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(EmployeeViewModel employeeViewModel, [FromRoute] int id)
        {
            if (id != employeeViewModel.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);

                    _unitOfWork.EmployeeRepository.Delete(MappedEmployee);
                    _unitOfWork.Complete(); 
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeViewModel);
        }
    }
}