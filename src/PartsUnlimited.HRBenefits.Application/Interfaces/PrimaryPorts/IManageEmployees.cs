﻿using System.Collections.Generic;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.Application.Interfaces.PrimaryPorts
{
    public interface IManageEmployees
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void Update(Employee employee);
    }
}