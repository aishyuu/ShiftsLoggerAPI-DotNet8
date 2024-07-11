using Newtonsoft.Json;
using ShiftsLoggerUI.Models;
using Spectre.Console;
using System.Net;
using System.Net.Http.Json;

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

    public static async void AddNewShift(HttpClient client, Shift newShift)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7004/api/Shift", newShift);
        if(response.StatusCode == HttpStatusCode.OK)
        {
            AnsiConsole.MarkupInterpolated($"[green]Successful Addition[/]\n");
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            AnsiConsole.MarkupInterpolated($"[red]Mistakes were made![/]\n");
        }
    }

    public static async void UpdateShift(HttpClient client, Shift updatedShift)
    {
        using HttpResponseMessage response = await client.PutAsJsonAsync($"https://localhost:7004/api/Shift", updatedShift);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            AnsiConsole.MarkupInterpolated($"[green]Successful Update[/]\n");
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            AnsiConsole.MarkupInterpolated($"[red]Mistakes were made![/]\n");
        }
    }

    public static async void DeleteShift(HttpClient client, int id)
    {
        using HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7004/api/Shift?id={id}");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            AnsiConsole.MarkupInterpolated($"[green]Successful Deletion[/]\n");
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            AnsiConsole.MarkupInterpolated($"[red]Mistakes were made![/]\n");
        }
    }
}
