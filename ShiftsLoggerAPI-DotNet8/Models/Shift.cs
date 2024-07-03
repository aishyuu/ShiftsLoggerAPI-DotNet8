namespace ShiftsLoggerAPI_DotNet8.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; } = string.Empty;
        public string EmployeeLastName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
