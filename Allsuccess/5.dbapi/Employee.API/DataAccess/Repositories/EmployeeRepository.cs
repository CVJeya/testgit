using Employee.DataAccessLayer.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
           
            List<Employee> members = await _context.Employees.ToListAsync();
            if (members != null && members.Count > 0)
            {
                return members;
            }
            return null;
        }

        public Employee GetEmployee(string employeeId)
        {
            return _context.Employees.SingleOrDefault(a => a.Id == employeeId);
        }



        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Add(employee);
            Save();
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public List<Employee> GetEmployees()
        {

            List<Employee> members = _context.Employees.ToList();
            if (members != null && members.Count > 0)
            {
                return members;
            }
            return null;
        }



    }
}
