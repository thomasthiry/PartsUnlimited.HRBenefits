using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PartsUnlimited.HRBenefits.Web.Controllers
{
    public class OnlineApiController : Controller
    {
        public IActionResult BaseHolidays(int employeeId)
        {
            var baseHolidaysForEmployees = new Dictionary<int, int>
            {
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
