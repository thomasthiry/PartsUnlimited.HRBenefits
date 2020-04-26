using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Interfaces.PrimaryPorts;
using PartsUnlimited.HRBenefits.Web.ViewModels;

namespace PartsUnlimited.HRBenefits.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IManageEmployees _employeeService;

        public EmployeeController(IManageEmployees employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult List()
        {
            var employees = _employeeService.GetEmployees();

            var employeesViewModel = new EmployeesViewModel
            {
                Employees = employees.Select(Mapper.Map)
            };
            return View(employeesViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployee(id);

            return View(Mapper.Map(employee));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm]EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeViewModel);
            }

            var employee = Mapper.Map(employeeViewModel);
            employee.Id = id;

            _employeeService.Update(employee);

            return RedirectToAction(nameof(List));
        }
    }
}
