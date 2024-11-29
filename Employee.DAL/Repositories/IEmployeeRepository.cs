using Employee.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity> FindById(int id);
        Task<List<EmployeeEntity>> FindAll();
        Task<EmployeeEntity> Create(EmployeeEntity employee);
        Task<bool> Delete(int id);
        Task<List<EmployeeEntity>> FindByName(string name);
        Task Update(EmployeeEntity entity);
    }
}
