using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace api_assignment.Controllers
{
    public class ManagersController : ApiController
    {



        public class Manager
        {
            public class Employeedata
            {
                public List<Employee> Emp { set; get; }
            }
            public Employeedata Edata;

            public int Mid;
            public string Mname;
            public int Mage;
            public string MDOB;
            public string Msalary;



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
        public List<Employee> Get(int id,string name)
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
        public Manager Get(int id)
        {
            var filepath = @"C:\Users\vjola\source\repos\api_assignment\InputFile.json";
            Manager m = null;

            var jsonData = System.IO.File.ReadAllText(filepath);
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData)
                                  ?? new List<Manager>();
            for (int i = 0; i < employeeList.Count; i++)
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
            int count = 2234, count1 = 2990;

            var jsonData = System.IO.File.ReadAllText(filepath);
            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<Manager>>(jsonData)
                                  ?? new List<Manager>();

            // Add any new employees
            employeeList.Add(new Manager()
            {
                Edata =
                {
                   Emp=
                    new List<Employee>(){
                    new Employee()
                    {
                        Eid=1237,
                        Ename="Jai Ballya"
                    },
                    new Employee()
                    {
                        Eid=1239,
                        Ename="khsaakf"
                    }

                    }
                    

                },
                Mid = count1++,
                Mname = "sai",
                Mage = 23,
                MDOB = "12/01/1998",
                Msalary = "5000000",
            });
            employeeList.Add(new Manager()
            {
                Edata = {

                    Emp= new List<Employee>(){
                    new Employee()
                    {
                        Eid=1240,
                        Ename="jai ho"
                    },
                    new Employee()
                    {
                        Eid=1242,
                        Ename="kitna"
                    }
                    }
                    }


                ,
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