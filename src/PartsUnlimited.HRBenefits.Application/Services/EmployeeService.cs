using System.Collections.Generic;
using PartsUnlimited.HRBenefits.Application.Interfaces;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    FirstName = "John",
                    LastName = "Doe"
                }
            };
        }
    }
}
