using Defra.UI.Tests.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace Defra.UI.Tests.Hooks
{
    [Binding]
    public class TestDependencies
    {
        public static IServiceCollection Services { get; set; } = new ServiceCollection();

        [ScenarioDependencies]
        public static IServiceCollection SetupDependencies()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigSetup.SetupProjectConfig();

            services.AddSingleton<BaseConfiguration, BaseConfiguration>();
            services.AddSingleton<IScenarioContext, ScenarioContext>();

            services = CapabilityService.SetupBrowserDependencies(services);
            services = WebDriverService.SetupDriverDependencies(services);
            services = PageServices.SetupPageDependencies(services);

            Services = services;

            return services;
        }
    }
}
