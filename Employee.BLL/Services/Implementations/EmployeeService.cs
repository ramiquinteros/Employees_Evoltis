using Employee.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Employee.Entity;
using Employee.BLL.Factory;
using Employee.DAL.Factory;

namespace Employee.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _employeeRepository = RepositoryFactory.CreateEmployeeRepository();

        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeRepository.FindById(id);
                
                if (employee == null)
                {
                    throw new KeyNotFoundException($"Empleado con ID {id} no encontrado.");
                }
                
                return employee;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo obtener el empleado. Intente nuevamente.", ex);
            }
        }

        public async Task<List<EmployeeEntity>> GetAllEmployees()
        {
            try
            {
                return await _employeeRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo obtener la lista de empleados. Intente nuevamente.", ex);
            }
        }

        public async Task<EmployeeEntity> CreateEmployee(EmployeeEntity employee)
        {
            try
            {
                return await _employeeRepository.Create(employee);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo crear el empleado. Intente nuevamente.", ex);
            }
        }

        public async Task UpdateEmployee(EmployeeEntity employee)
        {
            try
            {
                await _employeeRepository.Update(employee);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo actualizar el empleado. Intente nuevamente.", ex);
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var isUserDelte = await _employeeRepository.Delete(id);

                if (isUserDelte)
                {
                    return true;
                }

                throw new KeyNotFoundException("El empleado no existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<EmployeeEntity>> SearchEmployeesByName(string name)
        {
            try
            {
                return await _employeeRepository.FindByName(name);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudieron buscar empleados. Intente nuevamente.", ex);
            }
        }
    }
}
