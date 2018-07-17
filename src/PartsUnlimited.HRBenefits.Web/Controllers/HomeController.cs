using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Interfaces;
using PartsUnlimited.HRBenefits.Models;
using PartsUnlimited.HRBenefits.Web.ViewModels;

namespace PartsUnlimited.HRBenefits.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            var employees = _employeeService.GetEmployees();

            var employeesViewModel = new EmployeesViewModel
            {
                Employees = new List<EmployeeViewModel>
                {
                    new EmployeeViewModel
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    }
                }
            };
            return View(employeesViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
