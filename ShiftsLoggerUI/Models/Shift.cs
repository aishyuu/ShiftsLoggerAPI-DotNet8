namespace ShiftsLoggerUI.Models;

internal class Shift
{
    public int Id { get; set; }
    public string EmployeeFirstName { get; set; } = string.Empty;
    public string EmployeeLastName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
