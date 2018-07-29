﻿using System.Collections.Generic;
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

        public void Update(Employee employee)
        {
            using (var connection = GetConnection())
            {
                connection.Execute($@"
                    UPDATE public.employee 
                    SET
                        reference = @{nameof(employee.Reference)}, 
                        lastname = @{nameof(employee.LastName)}, 
                        firstname = @{nameof(employee.FirstName)}, 
                        dateofbirth = @{nameof(employee.DateOfBirth)}, 
                        addressnumber = @{nameof(employee.AddressNumber)}, 
                        addressstreet = @{nameof(employee.AddressStreet)}, 
                        addresscity = @{nameof(employee.AddressCity)}, 
                        addresspostalcode = @{nameof(employee.AddressPostalCode)}, 
                        addresscountry = @{nameof(employee.AddressCountry)}, 
                        joinedcompanydate = @{nameof(employee.JoinedCompanyDate)}, 
                        grossmonthlysalary = @{nameof(employee.GrossMonthlySalary)}, 
                        isgrantedcar = @{nameof(employee.IsGrantedCar)},
                        nbdaysyearlyholidays = @{nameof(employee.NbDaysYearlyHolidays)}
                    WHERE Id = @{nameof(employee.Id)};", 
                    new
                    {
                        employee.Id, 
                        employee.Reference, 
                        employee.LastName, 
                        employee.FirstName, 
                        employee.DateOfBirth, 
                        employee.AddressNumber, 
                        employee.AddressStreet, 
                        employee.AddressCity, 
                        employee.AddressPostalCode, 
                        employee.AddressCountry, 
                        employee.JoinedCompanyDate, 
                        employee.GrossMonthlySalary, 
                        employee.IsGrantedCar, 
                        employee.NbDaysYearlyHolidays
                    });
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("Host=localhost;Username=partsunlimited_hrbenefits;Password=hrbenefits;Database=partsunlimited_hrbenefits");
        }
    }
}