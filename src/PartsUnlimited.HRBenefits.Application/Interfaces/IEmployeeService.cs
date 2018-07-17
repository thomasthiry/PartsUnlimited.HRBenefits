using System.Collections;
using System.Collections.Generic;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
    }
}