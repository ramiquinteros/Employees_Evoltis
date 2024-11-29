using Employee.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.BLL.Factory
{
    public interface IEmployeeService
    {
        Task<EmployeeEntity> GetEmployeeById(int id);
        Task<List<EmployeeEntity>> GetAllEmployees();
        Task<EmployeeEntity> CreateEmployee(EmployeeEntity employee);
        Task UpdateEmployee(EmployeeEntity employee);
        Task<bool> DeleteEmployee(int id);
        Task<List<EmployeeEntity>> SearchEmployeesByName(string name);
    }
}
