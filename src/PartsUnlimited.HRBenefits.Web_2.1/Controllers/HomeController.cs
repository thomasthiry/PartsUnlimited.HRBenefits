using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.HRBenefits.Web.Models;

namespace PartsUnlimited.HRBenefits.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Represents an external system's api -- included in this web app to make it easier to manage
        [Route("externalsystem/baseholidays")]
        public IActionResult BaseHolidays(int employeeId)
        {
            var baseHolidaysForEmployees = new Dictionary<int, int>
            {
                { 0, 20 },
                { 1, 20 },
                { 2, 19 },
                { 3, 22 },
                { 4, 21 },
                { 5, 19 },
            };

            var baseHolidays = baseHolidaysForEmployees[employeeId % baseHolidaysForEmployees.Count];

            return new JsonResult(new { BaseHolidays = baseHolidays });
        }
    }
}
