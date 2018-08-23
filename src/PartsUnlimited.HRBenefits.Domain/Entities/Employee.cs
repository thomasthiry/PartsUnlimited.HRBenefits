using System;

namespace PartsUnlimited.HRBenefits.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int Reference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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

        public int NbDaysAdditionalHolidays => (PointsForAge + PointsForYearsInCompany) / PointsPerAdditionalDay;
        private const int YearsOfAgePerPoint = 5;
        private const int PointsPerAdditionalDay = 3;
        private const int YearsInCompanyPerPoint = 3;

        private int PointsForYearsInCompany => YearsInCompany/ YearsInCompanyPerPoint;

        private int YearsInCompany => (DateTime.Today - JoinedCompanyDate).Days / 365;

        private int PointsForAge => Age / YearsOfAgePerPoint;
        private int Age => (DateTime.Today - DateOfBirth).Days / 365;
    }
}