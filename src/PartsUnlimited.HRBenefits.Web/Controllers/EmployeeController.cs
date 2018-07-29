using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Interfaces.Services;
using PartsUnlimited.HRBenefits.Domain.Entities;
using PartsUnlimited.HRBenefits.Web.ViewModels;

namespace PartsUnlimited.HRBenefits.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var employees = _employeeService.GetEmployees();

            var employeesViewModel = new EmployeesViewModel
            {
                Employees = _mapper.Map<List<EmployeeViewModel>>(employees)
            };
            return View(employeesViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployee(id);

            return View(_mapper.Map<EmployeeViewModel>(employee));
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm]EmployeeViewModel employeeViewModel)
        {
            // check model is valid

            var employee = _mapper.Map<Employee>(employeeViewModel);
            employee.Id = id;

            _employeeService.Update(employee);

            return RedirectToAction(nameof(List));
        }
    }
}
