using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PartsUnlimited.HRBenefits.Application.Interfaces.Infrastructure;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.ComponentTests.TestDoubles
{
    public class EmployeeRepositoryStub : IEmployeeRepository
    {
        public List<Employee> Employees = new List<Employee>();

        public IEnumerable<Employee> GetEmployees()
        {
            var jsonCopyOfEmployees = JsonConvert.SerializeObject(Employees);
            return JsonConvert.DeserializeObject<List<Employee>>(jsonCopyOfEmployees);
        }

        public Employee GetEmployee(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            var jsonCopyOfEmployee = JsonConvert.SerializeObject(employee);
            return JsonConvert.DeserializeObject<Employee>(jsonCopyOfEmployee);
        }

        public void Update(Employee employee)
        {
            var employeeToUpdate = Employees.Single(e => e.Id == employee.Id);

            employeeToUpdate.Id = employee.Id;
            employeeToUpdate.Reference = employee.Reference;
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.DateOfBirth = employee.DateOfBirth;
            employeeToUpdate.AddressNumber = employee.AddressNumber;
            employeeToUpdate.AddressStreet = employee.AddressStreet;
            employeeToUpdate.AddressCity = employee.AddressCity;
            employeeToUpdate.AddressPostalCode = employee.AddressPostalCode;
            employeeToUpdate.AddressCountry = employee.AddressCountry;
            employeeToUpdate.JoinedCompanyDate = employee.JoinedCompanyDate;
            employeeToUpdate.GrossMonthlySalary = employee.GrossMonthlySalary;
            employeeToUpdate.IsGrantedCar = employee.IsGrantedCar;
            employeeToUpdate.NbDaysYearlyHolidays = employee.NbDaysYearlyHolidays;
        }
    }
}