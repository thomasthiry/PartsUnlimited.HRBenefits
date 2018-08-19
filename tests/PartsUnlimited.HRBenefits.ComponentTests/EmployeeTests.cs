using System;
using System.Linq;
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
        public void List_OneEmployee_ReturnsTheEmployee()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock), MapperConfig.CreateMapper());

            var result = controller.List() as ViewResult;
            var employeesViewModel = result.Model as EmployeesViewModel;

            employeesViewModel.Employees.ShouldHaveSingleItem();
        }

        [Fact]
        public void Edit_OneEmployee_CallsTheRepositoryAndRedirectsToList()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee{ Id = 1, FirstName = "Dale", LastName = "Cooper" });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock), MapperConfig.CreateMapper());

            var employeeEditionViewModel = new EmployeeViewModel{ Id = 1, FirstName = "Dale2", LastName = "Cooper2" };
            var result = controller.Edit(employeeEditionViewModel.Id, employeeEditionViewModel) as RedirectToActionResult;

            result.ActionName.ShouldBe("List");
            employeeRepositoryMock.Employees.First().LastName.ShouldBe(employeeEditionViewModel.LastName);
        }

        [Fact]
        public void ViewAdditionalDays_40YearsOld0YearsInCompany_Shows2Days()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee { Id = 1, FirstName = "Dale", LastName = "Cooper", DateOfBirth = DateTime.Today.AddYears(-40), JoinedCompanyDate = DateTime.Today });
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock), MapperConfig.CreateMapper());

            var result = controller.Edit(1) as ViewResult;
            var employeeViewModel = result.Model as EmployeeViewModel;

            employeeViewModel.NbDaysAdditionalHolidays.ShouldBe(2);
        }

        [Fact]
        public void ViewAdditionalDays_28YearsOld0YearsInCompany_Shows1Day()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee { Id = 1, FirstName = "Dale", LastName = "Cooper", DateOfBirth = DateTime.Today.AddYears(-28), JoinedCompanyDate = DateTime.Today});
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock), MapperConfig.CreateMapper());

            var result = controller.Edit(1) as ViewResult;
            var employeeViewModel = result.Model as EmployeeViewModel;

            employeeViewModel.NbDaysAdditionalHolidays.ShouldBe(1);
        }

        [Fact]
        public void ViewAdditionalDays_40YearsOld8YearsInCompany_Shows3Days()
        {
            var employeeRepositoryMock = new EmployeeRepositoryMock();
            employeeRepositoryMock.Employees.Add(new Employee { Id = 1, FirstName = "Dale", LastName = "Cooper", DateOfBirth = DateTime.Today.AddYears(-40), JoinedCompanyDate = DateTime.Today.AddYears(-8)});
            var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock), MapperConfig.CreateMapper());

            var result = controller.Edit(1) as ViewResult;
            var employeeViewModel = result.Model as EmployeeViewModel;

            employeeViewModel.NbDaysAdditionalHolidays.ShouldBe(3);
        }
    }
}
