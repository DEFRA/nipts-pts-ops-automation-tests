﻿namespace Capgemini.PowerApps.SpecFlowBindings.Steps;

using Capgemini.PowerApps.SpecFlowBindings.Extensions;
using FluentAssertions;
using Reqnroll;

/// <summary>
/// Step bindings relating to the command bar.
/// </summary>
[Binding]
public class CommandBarSteps : PowerAppsStepDefiner
{
    /// <summary>
    /// Selects a command with the given label.
    /// </summary>
    /// <param name="commandName">The label of the command.</param>
    [When("I select the '(.*)' command")]
    public static void WhenISelectTheCommand(string commandName)
    {
        XrmApp.CommandBar.ClickCommand(commandName);
    }

    /// <summary>
    /// Selects a command under a flyout with the given label.
    /// </summary>
    /// <param name="commandName">The label of the command.</param>
    /// <param name="flyoutName">The label of the flyout.</param>
    [When("I select the '([^']+)' command under the '([^']+)' flyout")]
    public static void WhenISelectTheCommandUnderTheFlyout(string commandName, string flyoutName)
    {
        XrmApp.CommandBar.ClickCommand(flyoutName, commandName);
    }

    /// <summary>
    /// Asserts that a command is available in the command bar.
    /// </summary>
    /// <param name="commandName">The label of the command.</param>
    [Then("I can see the '(.*)' command")]
    public static void ThenICanSeeTheCommand(string commandName)
    {
        XrmApp.CommandBar.GetCommandValues(true).Value.Should().Contain(commandName);
    }

    /// <summary>
    /// Asserts that a command is available in the command bar.
    /// </summary>
    /// <param name="commandName">The label of the command.</param>
    [Then("I can not see the '(.*)' command")]
    public static void ThenICanNotSeeTheCommand(string commandName)
    {
        XrmApp.CommandBar.GetCommandValues(true).Value.Should().NotContain(commandName);
    }
}
