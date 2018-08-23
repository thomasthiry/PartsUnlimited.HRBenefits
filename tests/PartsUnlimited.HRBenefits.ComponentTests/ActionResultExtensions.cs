using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Web.ViewModels;

namespace PartsUnlimited.HRBenefits.ComponentTests
{
    public static class ActionResultExtensions
    {
        public static EmployeeViewModel GetModel(this IActionResult result)
        {
            var viewResult = result as ViewResult;
            var employeeViewModel = viewResult.Model as EmployeeViewModel;

            return employeeViewModel;
        }
    }
}