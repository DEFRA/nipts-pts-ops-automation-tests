namespace Capgemini.PowerApps.SpecFlowBindings;

using OpenQA.Selenium;

/// <summary>
/// Exposes the state of the Dynamics 365 (EasyRepro) browser to consumers outside of the
/// <see cref="PowerAppsStepDefiner"/> inheritance chain (e.g. other test projects' hooks),
/// so they can determine which browser is actually active when capturing diagnostics
/// such as screenshots.
/// </summary>
public class DynamicsBrowserAccessor : PowerAppsStepDefiner
{
    /// <summary>
    /// Gets a value indicating whether the Dynamics 365 browser has been initiated for the current scenario.
    /// </summary>
    public static bool IsBrowserInitiated => Client.BrowserInitiated;

    /// <summary>
    /// Gets the Selenium <see cref="IWebDriver"/> for the Dynamics 365 browser.
    /// Only valid to call when <see cref="IsBrowserInitiated"/> is <c>true</c>.
    /// </summary>
    public static IWebDriver DynamicsDriver => Driver;
}
