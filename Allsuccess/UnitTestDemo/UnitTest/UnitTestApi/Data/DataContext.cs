using Microsoft.EntityFrameworkCore;

namespace UnitTestApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TaskInfo> TaskInfo { get; set; }
    }
}
