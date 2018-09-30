using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using PartsUnlimited.HRBenefits.Web;
using PartsUnlimited.HRBenefits.Web.Controllers;
using Shouldly;
using Xunit;

namespace PartsUnlimited.HRBenefits.ComponentTests
{
    public class IocContainerTests
    {
        [Fact]
        public void ResolveEmployeeController()
        {
            var startup = new Startup(null);
            var serviceCollection = (IServiceCollection) new ServiceCollection();
            startup.ConfigureServices(serviceCollection);
            serviceCollection.AddTransient<ILoggerFactory, LoggerFactory>();
            serviceCollection.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var controllerContext = new ControllerContext
            {
                ActionDescriptor = new ControllerActionDescriptor
                {
                    ControllerName = nameof(EmployeeController),
                    ControllerTypeInfo = typeof(EmployeeController).GetTypeInfo()
                },
                HttpContext = new DefaultHttpContext
                {
                    RequestServices = serviceProvider
                }
            };

            var controller = serviceProvider.GetService<IControllerFactory>().CreateController(controllerContext);

            controller.ShouldBeOfType(typeof(EmployeeController));
        }
    }
}