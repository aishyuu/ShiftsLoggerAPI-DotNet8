using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI_DotNet8.Data;
using ShiftsLoggerAPI_DotNet8.Models;

namespace ShiftsLoggerAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly DataContext _context;

        public ShiftController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shift>>> GetAllShifts()
        {
            var shifts = await _context.Shifts.ToListAsync();

            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Shift>>> GetShift(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if(shift is null)
            {
                return BadRequest("Shift not found!");
            }

            return Ok(shift);
        }

        [HttpPost]
        public async Task<ActionResult<List<Shift>>> AddShift(Shift newShift)
        {
            _context.Shifts.Add(newShift);
            await _context.SaveChangesAsync();

            return Ok(await _context.Shifts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Shift>>> UpdateShift(Shift updatedShift)
        {
            var shift = await _context.Shifts.FindAsync(updatedShift.Id);
            if (shift is null)
            {
                return BadRequest("Shift has not been found");
            }

            shift.EmployeeFirstName = updatedShift.EmployeeFirstName;
            shift.EmployeeLastName = updatedShift.EmployeeLastName;
            shift.StartTime = updatedShift.StartTime;
            shift.EndTime = updatedShift.EndTime;

            return Ok(await _context.Shifts.ToListAsync());
        }
    }
}
