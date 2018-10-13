using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.Infrastructure.Repositories
{
    public class EmployeeFileRepository
    {
        private readonly string _filePath;

        public EmployeeFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Update(Employee employee)
        {
            var employees = ReadEmployees();

            var employeeFromDb = employees.Single(e => e.Id == employee.Id);

            employeeFromDb.Id = employee.Id;
            employeeFromDb.Reference = employee.Reference;
            employeeFromDb.LastName = employee.LastName;
            employeeFromDb.FirstName = employee.FirstName;
            employeeFromDb.DateOfBirth = employee.DateOfBirth;
            employeeFromDb.AddressNumber = employee.AddressNumber;
            employeeFromDb.AddressStreet = employee.AddressStreet;
            employeeFromDb.AddressCity = employee.AddressCity;
            employeeFromDb.AddressPostalCode = employee.AddressPostalCode;
            employeeFromDb.AddressCountry = employee.AddressCountry;
            employeeFromDb.JoinedCompanyDate = employee.JoinedCompanyDate;
            employeeFromDb.GrossMonthlySalary = employee.GrossMonthlySalary;
            employeeFromDb.IsGrantedCar = employee.IsGrantedCar;
            employeeFromDb.NbDaysYearlyHolidays = employee.NbDaysYearlyHolidays;

            var jsonToWrite = JsonConvert.SerializeObject(employees);
            
            File.WriteAllText(_filePath, jsonToWrite);
        }

        private List<Employee> ReadEmployees()
        {
            var json = File.ReadAllText(_filePath);
            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            return employees;
        }

        public Employee GetEmployee(int id)
        {
            if (File.Exists(_filePath) == false)
            {
                return null;
            }

            var employees = ReadEmployees();

            return employees.Single(e => e.Id == id);
        }
    }
}