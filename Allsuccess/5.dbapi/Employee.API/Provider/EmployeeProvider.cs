using Employee.DataAccessLayer.Repositories;
using Employee.Provider.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Provider
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeProvider(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void AddEmployee(DataAccessLayer.Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }

        public DataAccessLayer.Employee GetEmployee(string employeeId)
        {
            return employeeRepository.GetEmployee(employeeId);
        }

        public async Task<List<DataAccessLayer.Employee>> GetEmployeesAsync()
        {
            List<DataAccessLayer.Employee> members = await employeeRepository.GetEmployeesAsync();
            return members;
        }

        List<DataAccessLayer.Employee> IEmployeeProvider.GetEmployees()
        {
            List<DataAccessLayer.Employee> members =  employeeRepository.GetEmployees();
            return members;
        }
    }
}
