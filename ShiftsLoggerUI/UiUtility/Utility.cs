using ShiftsLoggerUI.Models;
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
                    "Add a Shift",
                    "Update a Shift",
                    "Delete a Shift"
                }));

        return choice;
    }

    public static void displayShifts(List<Shift> shifts)
    {
        var table = new Table();
        table.AddColumns(new[] { "Id", "Date", "Name", "Hours", "Duration" });

        string[] shiftInfo = new string[5];

        foreach (var shift in shifts)
        {
            shiftInfo = new string[] { shift.Id.ToString(),
                    shift.StartTime.Date.ToString(),
                    $"{shift.EmployeeFirstName} {shift.EmployeeLastName}",
                    $"{shift.StartTime.ToString("t")} - {shift.EndTime.ToString("t")}",
                    $"{(shift.EndTime - shift.StartTime).TotalHours.ToString()}"};

            table.AddRow(shiftInfo);
        }
        
        AnsiConsole.Write(table);
    }
}
