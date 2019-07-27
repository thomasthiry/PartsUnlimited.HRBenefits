using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Services;
using PartsUnlimited.HRBenefits.ComponentTests.TestDoubles;
using PartsUnlimited.HRBenefits.Domain.Entities;
using PartsUnlimited.HRBenefits.Web.Controllers;
using PartsUnlimited.HRBenefits.Web.ViewModels;
using Shouldly;
using Xunit;

namespace PartsUnlimited.HRBenefits.ComponentTests.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void ViewListOfEmployees_WithOneEmployee_ReturnsTheEmployee()
        {
            var employeeRepositoryStub = new EmployeeRepositoryStub();
            employeeRepositoryStub.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryStub));

            var employeesViewModel = controller.List().ConvertTo<EmployeesViewModel>();

            employeesViewModel.Employees.ShouldHaveSingleItem();
            employeesViewModel.Employees.First().FirstName.ShouldBe("Dale");
        }

        [Fact]
        public void EditEmployee_SavesTheEmployeeAndRedirectsToList()
        {
            var employeeRepositoryStub = new EmployeeRepositoryStub();
            employeeRepositoryStub.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryStub));

            var employeeEditionViewModel = new EmployeeViewModel{ Id = 1, FirstName = "Dale2", LastName = "Cooper2" };
            var result = controller.Edit(employeeEditionViewModel.Id, employeeEditionViewModel) as RedirectToActionResult;

            result.ActionName.ShouldBe("List");
            employeeRepositoryStub.Employees.First().LastName.ShouldBe(employeeEditionViewModel.LastName);
        }
    }
}
