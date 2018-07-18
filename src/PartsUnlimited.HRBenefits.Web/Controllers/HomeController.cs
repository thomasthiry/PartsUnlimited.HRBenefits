using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Interfaces;
using PartsUnlimited.HRBenefits.Application.Interfaces.Services;
using PartsUnlimited.HRBenefits.Web.Models;
using PartsUnlimited.HRBenefits.Web.ViewModels;

namespace PartsUnlimited.HRBenefits.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public HomeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
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
                Employees = _mapper.Map<List<EmployeeViewModel>>(employees)
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
