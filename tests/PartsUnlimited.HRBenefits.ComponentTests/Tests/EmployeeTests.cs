using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Application.Services;
using PartsUnlimited.HRBenefits.ComponentTests.Mocks;
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
        public void List_OneEmployee_ReturnsTheEmployee()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

            var employeesViewModel = controller.List().ConvertTo<EmployeesViewModel>();

            employeesViewModel.Employees.ShouldHaveSingleItem();
            employeesViewModel.Employees.First().FirstName.ShouldBe("Dale");
        }

        [Fact]
        public void Edit_OneEmployee_CallsTheRepositoryAndRedirectsToList()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

            var employeeEditionViewModel = new EmployeeViewModel{ Id = 1, FirstName = "Dale2", LastName = "Cooper2" };
            var result = controller.Edit(employeeEditionViewModel.Id, employeeEditionViewModel) as RedirectToActionResult;

            result.ActionName.ShouldBe("List");
            employeeRepositoryMock.Employees.First().LastName.ShouldBe(employeeEditionViewModel.LastName);
        }
    }
}
