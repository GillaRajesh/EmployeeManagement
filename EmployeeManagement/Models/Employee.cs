using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeManagement.Models
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmployeeID { get; set; }

        [DataMember]
        public string EmployeeName { get; set; }


        [DataMember]
        public string Address { get; set; }
    }

}