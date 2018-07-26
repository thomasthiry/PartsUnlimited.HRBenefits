using System.Collections.Generic;
using PartsUnlimited.HRBenefits.Application.Interfaces.Infrastructure;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.ComponentTests.Mocks
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        public List<Employee> Employees = new List<Employee>();

        public IEnumerable<Employee> GetEmployees()
        {
            return Employees;
        }
    }
}