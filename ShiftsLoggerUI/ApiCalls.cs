using Newtonsoft.Json;
using ShiftsLoggerUI.Models;
using Spectre.Console;
using System.Net;

namespace ShiftsLoggerUI;

internal class ApiCalls
{
    public static async Task<List<Shift>> GetAllShifts(HttpClient client)
    {
        using HttpResponseMessage response = await client.GetAsync("https://localhost:7004/api/Shift");
        var stringResponse = await response.Content.ReadAsStringAsync();
        List<Shift> jsonResponse = JsonConvert.DeserializeObject<List<Shift>>(stringResponse);

        return jsonResponse;
    }

    public static async Task<Shift> GetSingleShift(HttpClient client, int id)
    {
        using HttpResponseMessage response = await client.GetAsync($"https://localhost:7004/api/Shift/{id}");
        if(response.StatusCode == HttpStatusCode.BadRequest)
        {
            AnsiConsole.MarkupInterpolated($"[red]Shift not found![/]\n");
            return new Shift();
        }
        var stringResponse = await response.Content.ReadAsStringAsync();
        Shift jsonResponse = JsonConvert.DeserializeObject<Shift>(stringResponse);

        return jsonResponse;
    }
}
