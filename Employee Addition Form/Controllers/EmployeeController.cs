using AutoMapper;
using Employee_Addition_Form.BLL.Interfaces;
using Employee_Addition_Form.DAL.Entities;
using Employee_Addition_Form.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var MappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);

                await _unitOfWork.EmployeeRepository.AddAsync(MappedEmployee);
                var result = await _unitOfWork.CompleteAsync();
                if (result > 0)
                    TempData["CreateMessage"] = "Employee Is Added Sucessfully";
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest(); //status code 400

            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id.Value);

            if (employee is null)
                return NotFound();

            var MappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(viewName, MappedEmployee);
        }

        [HttpGet]
        public Task<IActionResult> Edit(int? id)
        {
            return Details(id, "Edit");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel, [FromRoute] int id)
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
                    var result = await _unitOfWork.CompleteAsync();

                    if (result > 0)
                        TempData["UpdateMessage"] = "Employee Is Updated Sucessfully";

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
        public Task<IActionResult> Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeViewModel, [FromRoute] int id)
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
                    var result = await _unitOfWork.CompleteAsync();

                    if (result > 0)
                        TempData["DeleteMessage"] = "Employee Is Deleted Sucessfully";

                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeViewModel);
        }

        public async Task<IActionResult> Options()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var MappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappedEmployees);
        }
    }
}