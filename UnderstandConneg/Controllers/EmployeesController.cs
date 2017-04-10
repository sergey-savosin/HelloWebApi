using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace HelloWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private static IList<Employee> list = new List<Employee>()
        {
            new Employee()
            {
                Id = 12345, FirstName = "John", LastName = "Human", Department = 2
            },
            new Employee()
            {
                Id = 12346, FirstName = "Jane", LastName = "Public", Department = 3
            },
            new Employee()
            {
                Id = 12347, FirstName = "Joseph", LastName = "Law", Department = 2
            }
        };

        // Action methods go here

        // GET api/employees/12345
        public Employee Get(int id)
        {
            Employee employee = list.FirstOrDefault(e => e.Id == id);

            return employee;
        }
        public int Post(Employee employee)
        {
            return new Random().Next();
        }
    }
}
