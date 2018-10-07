using Microsoft.AspNetCore.Mvc;

namespace PartsUnlimited.HRBenefits.ComponentTests
{
    public static class ActionResultExtension
    {
        public static TModel ConvertTo<TModel>(this IActionResult actionResult) where TModel : class
        {
            var viewResult = actionResult as ViewResult;
            return viewResult?.Model as TModel;
        }
    }
}