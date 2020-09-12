using System.Collections.Generic;
using EmployeeManagementAngularSpaApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAngularSpaApplication.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer emp = new EmployeeDataAccessLayer();
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index()
        {
            return emp.GetAllEmployees();
        }
        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Employee employee)
        {
            return emp.AddEmployee(employee);
        }
        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(int id)
        {
            return emp.GetEmployeeData(id);
        }
        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody] Employee employee)
        {
            return emp.UpdateEmployee(employee);
        }
        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return emp.DeleteEmployee(id);
        }
    }
}
