using System;
using System.Collections.Generic;

namespace Employee.Provider.Contracts
{
    public interface IEmployeeProvider
    {
        
       
        DataAccessLayer.Employee GetEmployee(string employeeId);
        void AddEmployee(DataAccessLayer.Employee employee);
        List<DataAccessLayer.Employee> GetEmployees();
    }
}
