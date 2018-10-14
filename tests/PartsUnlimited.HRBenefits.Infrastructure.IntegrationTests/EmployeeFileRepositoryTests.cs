using System.IO;
using PartsUnlimited.HRBenefits.Domain.Entities;
using PartsUnlimited.HRBenefits.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace PartsUnlimited.HRBenefits.Infrastructure.IntegrationTests
{
    public class EmployeeFileRepositoryTests
    {
        private const string FilePath = "employees.json";

        private static EmployeeFileRepository CreateRepository()
        {
            return new EmployeeFileRepository(FilePath);
        }

        [Fact]
        public void Update()
        {
            var repository = CreateRepository();

            repository.Update(new Employee
            {
                Id = 1,
                FirstName = "Jean-Claude",
                LastName = "Van Damme"
            });

            var employee = repository.GetEmployee(1);
            employee.FirstName.ShouldBe("Jean-Claude");

            repository.Update(new Employee
            {
                Id = 1,
                FirstName = "Memorial",
                LastName = "Van Damme"
            });

            employee = repository.GetEmployee(1);
            employee.FirstName.ShouldBe("Memorial");
        }

        [Fact]
        public void GetEmployee()
        {
            var repository = CreateRepository();

            var employee = repository.GetEmployee(1);

            employee.LastName.ShouldBe("Van Damme");
        }

        [Fact]
        public void GetEmployee_FileDoesNotExist_ReturnsNull()
        {
            var repository = new EmployeeFileRepository("non-existing-file.json");

            var employee = repository.GetEmployee(1);

            employee.ShouldBeNull();
        }

        [Fact]
        public void GetEmployees()
        {
            var repository = CreateRepository();

            var employees = repository.GetEmployees();

            employees.ShouldNotBeEmpty();
        }
    }
}