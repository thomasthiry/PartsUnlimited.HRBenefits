using System;

namespace PartsUnlimited.HRBenefits.Domain.Entities
{
    public class Employee
    {
        private const int YearsOfAgeForAHolidayPoint = 5;
        private const int HolidayPointsForAnExtraHoliday = 3;
        private const int YearsOfSeniorityForAHolidayPoint = 3;
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

        public int NbExtraHolidays => ExtraHolidaysForAge + ExtraHolidaysForSeniority;
        private int ExtraHolidaysForSeniority => Seniority / YearsOfSeniorityForAHolidayPoint / HolidayPointsForAnExtraHoliday;
        private int ExtraHolidaysForAge => Age / YearsOfAgeForAHolidayPoint / HolidayPointsForAnExtraHoliday;
        private int Seniority => (DateTime.Today.Year - JoinedCompanyDate.Year);
        private int Age => DateTime.Today.Year - DateOfBirth.Year;
    }
}