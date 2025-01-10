using Defra.UI.Framework.Object;
using Defra.UI.Tests.Capabilities;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Hooks
{
    public class WebDriverService
    {
        public static IServiceCollection SetupDriverDependencies(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var driverOptionService = provider.GetRequiredService<IDriverOptions>();
            var site = new Site();
            site.With(driverOptionService.GetDriverOptions());

            services.AddSingleton<IWebDriver>(x =>
            {
                return site.WebDriver.Driver;
            });

            return services;
        }
    }
}
