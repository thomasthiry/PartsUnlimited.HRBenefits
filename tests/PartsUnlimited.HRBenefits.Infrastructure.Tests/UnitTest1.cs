using System;
using PartsUnlimited.HRBenefits.Infrastructure.Repositories;
using Xunit;

namespace PartsUnlimited.HRBenefits.Infrastructure.Tests
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public void GetEmployees()
        {
            var employeeRepository = new EmployeeRepository();

            var employees = employeeRepository.GetEmployees();
        }
    }
}

