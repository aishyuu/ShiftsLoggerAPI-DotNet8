using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI_DotNet8.Models;

namespace ShiftsLoggerAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Shift>>> GetAllShifts()
        {
            var shifts = new List<Shift>
            {
                new Shift
                {
                    Id = 1,
                    EmployeeFirstName = "John",
                    EmployeeLastName = "Smith",
                    StartTime = new DateTime(2024, 7, 1, 9, 0, 0),
                    EndTime = new DateTime(2024, 7, 1, 16, 0, 0)
                }
            };

            return Ok(shifts);
        }
    }
}
