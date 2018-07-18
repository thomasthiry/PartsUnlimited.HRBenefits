using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;
using PartsUnlimited.HRBenefits.Application.Interfaces.Infrastructure;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=partsunlimited_hrbenefits;Password=hrbenefits;Database=partsunlimited_hrbenefits"))
            {
                //connection.Open();
                //connection.Execute("Insert into Employee (first_name, last_name, address) values ('John', 'Smith', '123 Duane St');");
                return connection.Query<Employee>("Select * from Employee;");
            }
        }
    }
}