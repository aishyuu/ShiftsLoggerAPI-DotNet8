using ShiftsLoggerUI.Models;
using Spectre.Console;
using System.Globalization;
using System.Text.RegularExpressions;

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
                    shift.StartTime.Date.ToString("d"),
                    $"{shift.EmployeeFirstName} {shift.EmployeeLastName}",
                    $"{shift.StartTime.ToString("t")} - {shift.EndTime.ToString("t")}",
                    $"{(shift.EndTime - shift.StartTime).TotalHours.ToString()}"};

            table.AddRow(shiftInfo);
        }
        
        AnsiConsole.Write(table);
    }

    public static void displayShift(Shift shift)
    {
        var table = new Table();
        table.AddColumns(new[] { "Id", "Date", "Name", "Hours", "Duration" });

        table.AddRow($"{shift.Id.ToString()}",
            shift.StartTime.Date.ToString("d"),
            $"{shift.EmployeeFirstName} {shift.EmployeeLastName}",
            $"{shift.StartTime.ToString("t")} - {shift.EndTime.ToString("t")}",
            $"{(shift.EndTime - shift.StartTime).TotalHours.ToString()}");

        AnsiConsole.Write(table);
    }

    public static Shift createNewShift()
    {
        string employeeFirstName = AnsiConsole.Ask<string>("What's the first name of the employee?");
        string employeeLastName = AnsiConsole.Ask<string>("What's the last name of the employee?");

        CultureInfo culture = new CultureInfo("en-US");

        DateTime startDateTime;
        string startTime = AnsiConsole.Ask<string>("Enter date and time of shift start." +
            "\nFormat: MM/DD/YYYY HH:MM:SS AM/PM" +
            "\nExample: 10/31/2000 5:15:15 PM\n");


        while(true)
        {
            if(DateTime.TryParse(startTime, out startDateTime))
            {
                startDateTime = Convert.ToDateTime(startTime, culture);
                break;
            }

            startTime = AnsiConsole.Ask<string>("Incorrect format. Try again!");
        }

        DateTime endDateTime;
        string endTime = AnsiConsole.Ask<string>("Enter date and time of shift end." +
            "\nFormat: MM/DD/YYYY HH:MM:SS AM/PM" +
            "\nExample: 10/31/2000 5:15:15 PM\n");

        while(true)
        {
            if(DateTime.TryParse(endTime, out endDateTime))
            {
                endDateTime = Convert.ToDateTime(endTime, culture);
                break;
            }

            endTime = AnsiConsole.Ask<string>("Incorrect format. Try again!");
        }

        return new Shift()
        {
            EmployeeFirstName = employeeFirstName,
            EmployeeLastName = employeeLastName,
            StartTime = startDateTime,
            EndTime = endDateTime
        };
    }

    public static Shift UpdateShift(Shift shift)
    {
        Console.WriteLine("What's the first name of the employee? Enter nothing if you don't want to change.");
        string employeeFirstName = Console.ReadLine();
        Console.WriteLine("What's the last name of the employee? Enter nothing if you don't want to change.");
        string employeeLastName = Console.ReadLine();

        if (employeeFirstName != "")
        {
            shift.EmployeeFirstName = employeeFirstName;
        }
        if(employeeLastName != "")
        {
            shift.EmployeeLastName = employeeLastName;
        }

        CultureInfo culture = new CultureInfo("en-US");

        DateTime startDateTime;
        Console.WriteLine("Enter date and time of shift start." +
            "\nFormat: MM/DD/YYYY HH:MM:SS AM/PM" +
            "\nExample: 10/31/2000 5:15:15 PM\n" +
            "Enter nothing if you don't want to change!\n");

        string startTime = Console.ReadLine();

        while (true)
        {
            if (startTime == "")
            {
                break;
            }

            if (DateTime.TryParse(startTime, out startDateTime))
            {
                startDateTime = Convert.ToDateTime(startTime, culture);
                shift.StartTime = startDateTime;
                break;
            }

            startTime = AnsiConsole.Ask<string>("Incorrect format. Try again!");
        }

        DateTime endDateTime;
        string endTime = AnsiConsole.Ask<string>("Enter date and time of shift end." +
            "\nFormat: MM/DD/YYYY HH:MM:SS AM/PM" +
            "\nExample: 10/31/2000 5:15:15 PM\n");

        while (true)
        {
            if (endTime == "")
            {
                break;
            }

            if (DateTime.TryParse(endTime, out endDateTime))
            {
                endDateTime = Convert.ToDateTime(endTime, culture);
                shift.EndTime = endDateTime;
                break;
            }

            endTime = AnsiConsole.Ask<string>("Incorrect format. Try again!");
        }

        return shift;
    }
}
