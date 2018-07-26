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
            using (var connection = GetConnection())
            {
                return connection.Query<Employee>("Select * from Employee");
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Employee>("Select * from Employee where id = @EmployeeId", new { EmployeeId = id }).FirstOrDefault();
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("Host=localhost;Username=partsunlimited_hrbenefits;Password=hrbenefits;Database=partsunlimited_hrbenefits");
        }
    }
}