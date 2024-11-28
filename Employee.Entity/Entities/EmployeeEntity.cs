using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Entity
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }
}
