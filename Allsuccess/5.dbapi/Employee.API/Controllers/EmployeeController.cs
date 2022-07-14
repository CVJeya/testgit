using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider employeeProvider;

        public EmployeeController(IEmployeeProvider employeeProvider)
        {
            this.employeeProvider = employeeProvider;
        }

        [HttpGet("GetEmployees")]
        public ActionResult<IEnumerable<DataAccessLayer.Employee>> GetEmployees()
        {
            var buffered = employeeProvider.GetEmployees().ToList();
            if (buffered.Count > 0)
                return buffered;
            else
                return null;
        }

        [HttpGet("{employeeId}")]
        public ActionResult<DataAccessLayer.Employee> GetEmployee(string employeeId)
        {
            return employeeProvider.GetEmployee(employeeId);
        }

        [HttpPost]
        public void AddEmployee(DataAccessLayer.Employee employee)
        {
            employeeProvider.AddEmployee(employee);
        }
    }
}
