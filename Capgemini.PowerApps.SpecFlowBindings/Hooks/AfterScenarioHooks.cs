﻿namespace Capgemini.PowerApps.SpecFlowBindings.Hooks;

using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using Reqnroll;

/// <summary>
/// After scenario hooks.
/// </summary>
[Binding]
public class AfterScenarioHooks : PowerAppsStepDefiner
{
    private readonly ScenarioContext scenarioContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AfterScenarioHooks"/> class.
    /// </summary>
    /// <param name="scenarioContext">The scenario context.</param>
    public AfterScenarioHooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    /// <summary>
    /// Deletes the test data created during the test and disposes of the browser.
    /// </summary>
    [AfterScenario(Order = 1)]
    public static void TestCleanup()
    {
        if (!Client.BrowserInitiated)
            return;
        try
        {
            TestDriver.DeleteTestData();
        }
        catch (WebDriverException)
        {
            // Ignore - tests might have failed before driver was initialised.
        }
        finally
        {
            Quit();
        }
    }

    /// <summary>
    /// Takes a screenshot of the browser when a test fails.
    /// </summary>
    //[AfterScenario(Order = 0)]
    public void ScreenshotFailedScenario()
    {
        if (this.scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError && Client.BrowserInitiated)
        {
            var rootFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var screenshotsFolder = Path.Combine(rootFolder, "screenshots");
            Console.WriteLine(screenshotsFolder);

            if (!Directory.Exists(screenshotsFolder))
            {
                Directory.CreateDirectory(screenshotsFolder);
            }

            var fileName = string.Concat(this.scenarioContext.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars()));
            var screenshotPath = Path.Combine(screenshotsFolder, $"{fileName.Replace(" ", "")}.jpg");
            Client.Browser.TakeWindowScreenShot(screenshotPath, ScreenshotImageFormat.Jpeg);
            Console.WriteLine(new Uri(screenshotPath));
        }
    }
}
