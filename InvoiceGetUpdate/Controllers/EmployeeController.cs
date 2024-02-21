using InvoiceGetUpdate.Models;
using InvoiceGetUpdate.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceGetUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataBaseContext baseContext;
        public EmployeeController(DataBaseContext baseContext)
        {
            this.baseContext = baseContext;
        }

        [HttpGet("getEmployeesWithDepartments")]
        public ActionResult<List<EmployeeView>> GetEmployeesWithDepartments()
        {
            var employeeList = (from emp in baseContext.employees
                                join dept in baseContext.departments on emp.deptid equals dept.id
                                select new EmployeeView
                                {
                                    id = emp.id,
                                    FirstName = emp.FirstName,
                                    LastName = emp.LastName,
                                    Email = emp.Email,
                                    deptname = dept.name,
                                    location = dept.location
                                }).ToList();

            return employeeList;
        }
        [HttpPut("updateEmployeeDepartment")]
        public ActionResult UpdateEmployeeDepartment([FromBody] UpdateEmployeeDepartmentRequest request)
        {
            try
            {
                var employee = baseContext.employees.FirstOrDefault(e => e.id == request.employeeId);
                if (employee != null)
                {
                    employee.deptid = request.NewDepartmentId;

                }
                baseContext.SaveChanges();
                return Ok($"Department updated for Employee ID {request.employeeId}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error:{ex.Message}");
            }

        }

    }
}
