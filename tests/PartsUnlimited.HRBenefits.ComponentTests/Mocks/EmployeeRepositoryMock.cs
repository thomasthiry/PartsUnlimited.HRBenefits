using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PartsUnlimited.HRBenefits.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRBenefits.Domain.Entities;

namespace PartsUnlimited.HRBenefits.ComponentTests.Mocks
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        public List<Employee> Employees = new List<Employee>();

        public IEnumerable<Employee> GetEmployees()
        {
            return CopyOfObject(Employees);
        }

        public Employee GetEmployee(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            return CopyOfObject(employee);
        }

        private static T CopyOfObject<T>(T objectToCopy)
        {
            var jsonCopyOfObject = JsonConvert.SerializeObject(objectToCopy);
            return JsonConvert.DeserializeObject<T>(jsonCopyOfObject);
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