using System;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Services;
using PartsUnlimited.HRBenefits.ComponentTests.Mocks;
using PartsUnlimited.HRBenefits.Domain.Entities;
using PartsUnlimited.HRBenefits.Web.Configuration;
using PartsUnlimited.HRBenefits.Web.Controllers;
using PartsUnlimited.HRBenefits.Web.ViewModels;
using Shouldly;
using Xunit;

namespace PartsUnlimited.HRBenefits.ComponentTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employees_OneEmployee_ReturnsTheEmployee()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new HomeController(new EmployeeService(employeeRepositoryMock), MapperConfig.CreateMapper());

            var result = controller.Employees() as ViewResult;
            var employeesViewModel = result.Model as EmployeesViewModel;

            employeesViewModel.Employees.ShouldHaveSingleItem();
        }
    }
}
