using Newtonsoft.Json;
using ShiftsLoggerUI;
using ShiftsLoggerUI.Models;
using ShiftsLoggerUI.UiUtility;
using Spectre.Console;

HttpClient client = new HttpClient();

bool isRunning = true;

while (isRunning)
{
    string userChoice = Utility.userChoice();

    switch(userChoice)
    {
        case "View All Shifts":
            var shifts = await ApiCalls.GetAllShifts(client);
            Utility.displayShifts(shifts);
            break;

        case "View One Shift":
            var id = AnsiConsole.Ask<int>("Insert [green]id[/]");
            var shift = await ApiCalls.GetSingleShift(client, id);
            Utility.displayShift(shift);
            break;

        case "Add a Shift":
            var newShift = Utility.createNewShift();
            ApiCalls.AddNewShift(client, newShift);
            break;

        case "Update a Shift":
            var updateId = AnsiConsole.Ask<int>("Insert [green]id[/]");
            var updateShift = await ApiCalls.GetSingleShift(client, updateId);
            var updatedShift = Utility.UpdateShift(updateShift);
            break;

        case "Delete a Shift":
            break;
    }
}