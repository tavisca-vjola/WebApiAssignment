using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_assignment.Controllers
{
    public class ManagersController : ApiController
    {
      

        public class Manager
        {
   
            public int Mid;
            public string Mname;
            public int Mage;
            public  string MDOB;
            public string  Msalary;
            public Employee emp;

        }
        public class Employee
        {
            public int Eid;
            public string Ename;

        }
     
        public object Get()
        {
            var filepath = @"C:\Users\vjola\source\repos\api_assignment\InputFile.json";
            string allText = System.IO.File.ReadAllText(filepath);
            object jsonObject = JsonConvert.DeserializeObject(allText);
            return jsonObject;
        }

        // GET api/values/5
        public List<Manager> Get(int id ,string name)
        {
            List<Manager> employee = new List<Manager>();

            if (name == "Employee")
            {

                var filepath = @"C:\Users\vjola\source\repos\api_assignment\InputFile.json";
             

                var jsonData = System.IO.File.ReadAllText(filepath);
                // De-serialize to object or create new list
                var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData)
                                      ?? new List<Manager>();
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].emp.Eid < id)
                    {
                        employee.Add(employeeList[i]);
                    }
                }
            }
                return employee;
            
          
        }
        public Manager Get(int id)
        {
            var filepath = @"C:\Users\vjola\source\repos\api_assignment\InputFile.json";
            Manager m = null;

            var jsonData = System.IO.File.ReadAllText(filepath);
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData)
                                  ?? new List<Manager>();
            for(int i=0;i<employeeList.Count;i++)
            {
                if (employeeList[i].Mid == id)
                    return employeeList[i];

            }
            
            return m;
            
          
        }

        // POST api/values
        public void Post()
        {
            var filepath = @"C:\Users\vjola\source\repos\api_assignment\InputFile.json";
            int count = 1234,count1=1990;
           
            var jsonData = System.IO.File.ReadAllText(filepath);
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData)
                                  ?? new List<Manager>();
           
            // Add any new employees
            employeeList.Add(new Manager()
            {
                emp = new Employee
                {
                    Eid = count++,
                    Ename = "crazier"
                },
                Mid = count1++,
                Mname = "sai",
                Mage = 23,
                MDOB = "12/01/1998",
                Msalary = "5000000",
            });
            employeeList.Add(new Manager()
            {
                emp = new Employee
                {
                    Eid = count++,
                    Ename = "sulamon"
                },
                Mid = count1++,
                Mname = "sai",
                Mage = 23,
                MDOB = "12/01/1998",
                Msalary = "5000000",
            });

            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList);
            System.IO.File.WriteAllText(filepath, jsonData);
            // Manager deserializedProduct = JsonConvert.DeserializeObject<Manager>(output);



        }
        

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        // public void Delete(int id)
        //{
        //}
    }
}

