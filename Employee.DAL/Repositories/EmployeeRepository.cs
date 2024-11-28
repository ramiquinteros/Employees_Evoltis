using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Employee.Entity;

namespace Employee.DAL.Repositories
{
    public class EmployeeRepository 
    {
        readonly DataContext _context = new DataContext();

        public async Task<EmployeeEntity> FindById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<EmployeeEntity>> FindAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task Create(EmployeeEntity employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(); 
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Employees.FindAsync(id);

            if (user != null)
            {
                _context.Employees.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            
            return false;
        }

        public async Task<List<EmployeeEntity>> FindByName(string name)
        {
            return await _context.Employees
                                 .Where(emp => emp.Name.Contains(name)) 
                                 .ToListAsync();
        }

        public async Task Update(EmployeeEntity entity) 
        {
            var employee = await _context.Employees.FindAsync(entity.Id);

            if (employee is null) return;

            _context.Entry(employee).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
