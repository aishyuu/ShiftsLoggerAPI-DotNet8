using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI_DotNet8.Models;

namespace ShiftsLoggerAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Shift> Shifts { get; set; }
    }
}
