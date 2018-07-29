using System;

namespace PartsUnlimited.HRBenefits.Web.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Reference { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountry { get; set; }
        public DateTime JoinedCompanyDate { get; set; }
        public decimal GrossMonthlySalary { get; set; }
        public bool IsGrantedCar { get; set; }
        public int NbDaysYearlyHolidays { get; set; }
    }
}