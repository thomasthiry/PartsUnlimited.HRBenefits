using PartsUnlimited.HRBenefits.Domain.Entities;
using PartsUnlimited.HRBenefits.Web.ViewModels;

namespace PartsUnlimited.HRBenefits.Web.Controllers
{
    public static class Mapper
    {
        public static EmployeeViewModel Map(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Reference = employee.Reference,
                DateOfBirth = employee.DateOfBirth,
                AddressNumber = employee.AddressNumber,
                AddressStreet = employee.AddressStreet,
                AddressCity = employee.AddressCity,
                AddressPostalCode = employee.AddressPostalCode,
                AddressCountry = employee.AddressCountry,
                JoinedCompanyDate = employee.JoinedCompanyDate,
                GrossMonthlySalary = employee.GrossMonthlySalary,
                IsGrantedCar = employee.IsGrantedCar,
                NbDaysYearlyHolidays = employee.NbDaysYearlyHolidays,
                NbExtraHolidays = employee.NbExtraHolidays,
            };
        }

        public static Employee Map(EmployeeViewModel employee)
        {
            return new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Reference = employee.Reference,
                DateOfBirth = employee.DateOfBirth,
                AddressNumber = employee.AddressNumber,
                AddressStreet = employee.AddressStreet,
                AddressCity = employee.AddressCity,
                AddressPostalCode = employee.AddressPostalCode,
                AddressCountry = employee.AddressCountry,
                JoinedCompanyDate = employee.JoinedCompanyDate,
                GrossMonthlySalary = employee.GrossMonthlySalary,
                IsGrantedCar = employee.IsGrantedCar,
                NbDaysYearlyHolidays = employee.NbDaysYearlyHolidays,
            };
        }
    }
}