using System.Data.Entity;
using Employee.Entity;

namespace Employee.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
