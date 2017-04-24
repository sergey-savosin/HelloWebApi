using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using UnderstandConneg.Model;
using UnderstandConneg.Tech;

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

        //public HttpResponseMessage Get(Shift shift)
        //{
        //    // Do smth
        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent("")
        //    };

        //    return response;
        //}

        //public HttpResponseMessage Get(
        //    [ModelBinder]IEnumerable<string> ifmatch)
        //{
        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(ifmatch.First().ToString())
        //    };

        //    return response;
        //}

        public HttpResponseMessage Get(
            [ModelBinder(typeof(TalentScoutModelBinderProvider))]
                TalentScout scout)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            return response;
        }

        public void Post(Employee employee)
        {
            // do nothing
        }
    }
}
