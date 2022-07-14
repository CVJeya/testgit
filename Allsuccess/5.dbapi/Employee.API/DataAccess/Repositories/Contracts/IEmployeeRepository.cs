using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.DataAccessLayer.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Employee GetEmployee(string employeeId);
        void AddEmployee(Employee employee);
        bool Save();
        List<Employee> GetEmployees();
    }
}
