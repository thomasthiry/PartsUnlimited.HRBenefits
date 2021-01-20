using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using PartsUnlimited.HRBenefits.Application.Services;
using PartsUnlimited.HRBenefits.Infrastructure.Repositories;
using PartsUnlimited.HRBenefits.Web.Controllers;

namespace PartsUnlimited.HRBenefits.Web
{
    public class CompositionRoot : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            if (context.ActionDescriptor.ControllerTypeInfo == typeof(HomeController))
            {
                return new HomeController(loggerFactory.CreateLogger(nameof(HomeController)));
            }
            if (context.ActionDescriptor.ControllerTypeInfo == typeof(EmployeeController))
            {
                return new EmployeeController(new EmployeeService(new EmployeeFileRepository("employees.json")));
            }
 
            return null;
        }

        public void Release(ControllerContext context, object controller)
        {
            
        }
    }}