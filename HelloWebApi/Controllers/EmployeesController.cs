using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

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

        // GET api/employees
        public IEnumerable<Employee> Get()
        {
            return list;
        }

        // GET api/employees/12345
        public IEnumerable<Employee> Get(int id)
        {
            return list.Where(e => e.Id == id);
        }

        // POST
        public HttpResponseMessage Post(Employee employee)
        {
            int maxId = list.Max(e => e.Id);
            employee.Id = maxId + 1;

            list.Add(employee);
            var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);

            string uri = Url.Link("DefaultApi", new { id = employee.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT
        public HttpResponseMessage Put(int id, Employee employee)
        {
            int index = list.ToList().FindIndex(e => e.Id == id);
            if (index >= 0)
            {
                list[index] = employee; // overwrite
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                list.Add(employee);

                var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);

                string uri = Url.Link("DefaultApi", new { id = employee.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }
        
        public HttpResponseMessage Patch(int id, Delta<Employee> deltaEmployee)
        {
            var employee = list.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            deltaEmployee.Patch(employee);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        //// POST api/employees
        //public void Post(Employee employee)
        //{
        //    int maxId = list.Max(e => e.Id);
        //    employee.Id = maxId + 1;
        //    list.Add(employee);
        //}

        //// PUT api/employees/12345
        //public void Put(int id, Employee employee)
        //{
        //    int index = list.ToList().FindIndex(e => e.Id == id);
        //    list[index] = employee;
        //}

        //// DELETE api/employees/12345
        //public void Delete(int id)
        //{
        //    Employee employee = Get(id);
        //    list.Remove(employee);
        //}
    }
}
