using Defra.UI.Tests.Capabilities;
using Defra.UI.Tests.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;

namespace Defra.UI.Tests.Hooks
{
    public class BrowserService
    {
        public static IServiceCollection SetupBrowserDependencies(IServiceCollection services)
        {
            var seleniumGrid = ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

            if (seleniumGrid.Contains("browserstack", StringComparison.InvariantCultureIgnoreCase))
            {
                services.AddSingleton<IDriverOptions, BrowserStackCapability>();
            }
            else if (seleniumGrid.Contains("localhost"))
            {
                var browser = ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.Target;

                switch (browser.ToUpper())
                {
                    case "CHROME":
                        services.AddSingleton<IDriverOptions>(provider =>
                        {
                            var scenarioContext = provider.GetService<ScenarioContext>();
                            return new ChromeCapability(scenarioContext);
                        });
                        break;
                    case "FIREFOX":
                        services.AddSingleton<IDriverOptions>(provider =>
                        {
                            var scenarioContext = provider.GetService<ScenarioContext>();
                            return new FirefoxCapability(scenarioContext);
                        });
                        break;
                    case "EDGE":
                        services.AddSingleton<IDriverOptions>(provider =>
                        {
                            var scenarioContext = provider.GetService<ScenarioContext>();
                            return new EdgeCapability(scenarioContext);
                        });
                        break;
                    default:
                        services.AddSingleton<IDriverOptions>(provider =>
                        {
                            var scenarioContext = provider.GetService<ScenarioContext>();
                            return new ChromeCapability(scenarioContext);
                        });
                        break;
                }
            }
            else
            {
                services.AddSingleton<IDriverOptions>(provider =>
                {
                    var scenarioContext = provider.GetService<ScenarioContext>();
                    return new ChromeCapability(scenarioContext);
                });
            }

            return services;
        }
    }
}
