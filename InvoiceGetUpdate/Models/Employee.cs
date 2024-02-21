using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceGetUpdate.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public int deptid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }

    }
    public class UpdateEmployeeDepartmentRequest
    {
        public int NewDepartmentId { get; set; }
        public int employeeId { get; set; }
    }
}
