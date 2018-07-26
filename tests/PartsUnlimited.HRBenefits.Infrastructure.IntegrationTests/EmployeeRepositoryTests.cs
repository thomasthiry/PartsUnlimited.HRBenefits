using PartsUnlimited.HRBenefits.Infrastructure.Repositories;
using Xunit;

namespace PartsUnlimited.HRBenefits.Infrastructure.IntegrationTests
{
    public class EmployeeRepositoryTests
    {
        [Fact(Skip = "Requires DB, used only for dev")]
        public void GetEmployees()
        {
            var employeeRepository = new EmployeeRepository();

            var employees = employeeRepository.GetEmployees();
        }

        [Fact(Skip = "Requires DB, used only for dev")]
        public void GetEmployee()
        {
            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetEmployee(1);
        }
    }
}

