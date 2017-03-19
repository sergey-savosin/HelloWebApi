using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.Tracing;

namespace HelloWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly ITraceWriter traceWriter = null;

        public EmployeesController()
        {
            this.traceWriter = GlobalConfiguration.Configuration.Services.GetTraceWriter();
        }

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
        public Employee Get(int id)
        {
            Employee employee = null;

            if (traceWriter != null)
            {
                traceWriter.TraceBeginEnd(
                    Request,
                    TraceCategories.FormattingCategory,
                    TraceLevel.Info,
                    "EmployeesController",
                    "Get",
                    beginTrace: (tr) =>
                    {
                        tr.Message = "Entering Get";
                    },
                    execute: () =>
                    {
                        System.Threading.Thread.Sleep(1000); //Simulate delay
                        employee = list.First(e => e.Id == id);
                    },
                    endTrace: (tr) =>
                    {
                        tr.Message = "Leaving Get";
                    },
                    errorTrace: null);

                /*
                traceWriter.Info(Request, "EmployeesController", String.Format($"Getting employee {id}"));
                traceWriter.Trace(Request,
                    "System.Web.Http.Conrollers", System.Web.Http.Tracing.TraceLevel.Info,
                    (traceRecord) =>
                    {
                        traceRecord.Message = String.Format($"Getting employee {id}");
                        traceRecord.Operation = "Get(int)";
                        traceRecord.Operator = "EmployeeController";
                    });
                    */
            }


            return employee;
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

        // DELETE api/employees/12345
        public void Delete(int id)
        {
            Employee employee = Get(id);
            list.Remove(employee);
        }
    }
}
