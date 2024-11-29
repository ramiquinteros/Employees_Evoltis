using Employee.BLL.Services;

namespace Employee.BLL.Factory
{
    public static class ServiceFactory
    {
        public static IEmployeeService CreateEmployeeService() { return new EmployeeService(); }
    }
}
