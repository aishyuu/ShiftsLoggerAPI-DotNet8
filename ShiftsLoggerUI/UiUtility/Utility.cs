using Spectre.Console;

namespace ShiftsLoggerUI.UiUtility;

internal class Utility
{
    public static string userChoice()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your action!")
                .AddChoices(new[]
                {
                    "View All Shifts",
                    "View One Shift",
                    "Add a shift",
                    "Update a shift",
                    "Delete a shift"
                }));

        return choice;
    }
}
