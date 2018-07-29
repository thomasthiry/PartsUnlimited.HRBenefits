using System;
using PartsUnlimited.HRBenefits.Domain.Entities;
using PartsUnlimited.HRBenefits.Infrastructure.Repositories;
using Xunit;

namespace PartsUnlimited.HRBenefits.Infrastructure.IntegrationTests
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public void GetEmployees()
        {
            var employeeRepository = new EmployeeRepository();

            var employees = employeeRepository.GetEmployees();
        }

        [Fact]
        public void GetEmployee()
        {
            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetEmployee(1);
        }

        [Fact]
        public void Update()
        {
            var employeeRepository = new EmployeeRepository();

            var employee = new Employee
            {
                Id = 1,
                FirstName = "Dale",
                LastName = "Cooper",
                Reference = 1,
                DateOfBirth = new DateTime(1959, 02, 22),
                AddressNumber = "54",
                AddressStreet = "Trees street",
                AddressCity = "Yakima, Washington",
                AddressPostalCode = "98908",
                AddressCountry = "USA",
                JoinedCompanyDate = DateTime.Now,
                GrossMonthlySalary = 3000m,
                IsGrantedCar = false,
                NbDaysYearlyHolidays = 20,
            };

            employeeRepository.Update(employee);
        }
    }
}

