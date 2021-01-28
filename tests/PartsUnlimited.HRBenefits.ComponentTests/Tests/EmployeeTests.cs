using System;
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
        public void View_list_of_employees_with_one_employee_returns_the_employee()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

            var employeesViewModel = controller.List().ConvertTo<EmployeesViewModel>();

            employeesViewModel.Employees.ShouldHaveSingleItem();
            employeesViewModel.Employees.First().FirstName.ShouldBe("Dale");
        }

        [Fact]
        public void Editing_an_employee_saves_the_employee_and_redirects_to_the_list()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

            var employeeEditionViewModel = new EmployeeViewModel{ Id = 1, FirstName = "Dale2", LastName = "Cooper2" };
            var result = controller.Edit(employeeEditionViewModel.Id, employeeEditionViewModel) as RedirectToActionResult;

            result.ActionName.ShouldBe("List");
            employeeRepositoryMock.Employees.First().LastName.ShouldBe(employeeEditionViewModel.LastName);
        }
        
        [Fact]
        public void Viewing_an_employee_shows_its_current_number_of_holidays()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, NbDaysYearlyHolidays = 25 });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

            var employeeViewModel = controller.Edit(1).ConvertTo<EmployeeViewModel>();

            employeeViewModel.NbDaysYearlyHolidays.ShouldBe(25);
        }

        [Fact]
        public void An_employee_who_is_37_and_joined_yesterday_should_have_2_extra_holidays()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, DateOfBirth = DateTime.Today.AddYears(-37), JoinedCompanyDate = DateTime.Today.AddDays(-1)});
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

            var employeeViewModel = controller.Edit(1).ConvertTo<EmployeeViewModel>();

            employeeViewModel.NbExtraHolidays.ShouldBe(2);
        }
    }
}
