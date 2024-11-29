using Employee.DAL.Repositories;

namespace Employee.DAL.Factory
{
    public static class RepositoryFactory
    {
        public static IEmployeeRepository CreateEmployeeRepository() {  return new  EmployeeRepository(); }
    }
}
