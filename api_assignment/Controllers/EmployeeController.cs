using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static api_assignment.Controllers.ManagersController;

namespace api_assignment.Controllers
{
    public class EmployeeController : ApiController
    {
        public List<Employee> Get(int id)
        {
            var filepath = @"C:\Users\vjola\source\repos\api_assignment\InputFile.json";
            List<Employee> employ = new List<Employee>();
            var jsonData = System.IO.File.ReadAllText(filepath);
            var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData) ?? new List<Manager>();
            for (int i = 0; i < employeeList.Count; i++)
            {
                for (int j = 0; j < employeeList[i].Edata.Emp.Count; j++)
                {

                    if (employeeList[i].Edata.Emp[j].Eid < id)
                    {
                        employ.Add(employeeList[i].Edata.Emp[j]);
                    }
                }
            }
            return employ;


        }
    }
}
