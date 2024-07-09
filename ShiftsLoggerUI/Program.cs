using Newtonsoft.Json;
using ShiftsLoggerUI;
using ShiftsLoggerUI.Models;
using ShiftsLoggerUI.UiUtility;

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
            break;

        case "Add a Shift":
            break;

        case "Update a Shift":
            break;

        case "Delete a Shift":
            break;
    }
}