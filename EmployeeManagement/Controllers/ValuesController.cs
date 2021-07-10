using EmployeeManagement.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Employee> Get()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee()
                {
                    EmployeeID = 1,
                    EmployeeName = "Rajesh",
                    Address = "USA"
                },

                new Employee()
                {
                    EmployeeID = 2,
                    EmployeeName = "Rupesh",
                    Address = "UAE"
                },

                new Employee()
                {
                    EmployeeID = 3,
                    EmployeeName = "Ramesh",
                    Address = "INDIA"
                }
            };

            return list;
            
        }

        // GET api/values/5
        [HttpGet]
        public Employee GetEmployee(int id)
        {
            List<Employee> lst = Get();

            return lst.FirstOrDefault(a => a.EmployeeID == id);           
        }

        [HttpPost]
        // POST api/values
        public List<Employee> SaveEmployee(JObject jObject)
        {

            JsonSerializer serializer = new JsonSerializer();
            Employee employee = (Employee)serializer.Deserialize(new JTokenReader(jObject), typeof(Employee));

            List<Employee> lst = Get();
            lst.Add(employee);

            return  lst;
        }

        [HttpPut]
        // PUT api/values/5
        public List<Employee> Update(JObject jObject)
        {
            JsonSerializer serializer = new JsonSerializer();
            Employee employee = (Employee)serializer.Deserialize(new JTokenReader(jObject), typeof(Employee));

            List<Employee> lst = Get();

            if (lst.Any(a => a.EmployeeID == employee.EmployeeID))
            {
                lst.Find(a => a.EmployeeID == employee.EmployeeID).EmployeeName = employee.EmployeeName;
                lst.Find(a => a.EmployeeID == employee.EmployeeID).Address = employee.Address;

                //lst.Remove(lst.Single(a => a.EmployeeID == employee.EmployeeID));
                //lst.Add(employee);

            }
            
            return lst;
        }

        [HttpDelete]
        // DELETE api/values/5
        public List<Employee> DeleteEmployee(int id )
        {
            List<Employee> lst = Get();

            var remove = lst.Single(a => a.EmployeeID == id);
            lst.Remove(remove);

            return lst;
        }
    }
}
