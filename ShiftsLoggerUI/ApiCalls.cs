using Newtonsoft.Json;
using ShiftsLoggerUI.Models;

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
}
