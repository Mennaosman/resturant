using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace resturant
{
    public class Admin:Employee
    {

       // public Admin(int EmpId, int EmpSalary, string EmpName, string UserName, string UserPassword, string UserRole) : base(EmpId, EmpSalary, EmpName, UserName, UserPassword, "Admin") { }
       /*
        Customer customer = new Customer();
        order order = new order();
        reservations reservations = new reservations();
        */        
        //private static Admin MyAdmin;
        public static List<Employee> Employees = new List<Employee> { };
        public static List<Employee> UserEmp = new List<Employee> { };
      
        public Admin()
        { }
        
        
        //Customer customer = new Customer();
        //order order = new order();
        // public static List<Customer> CustomerData = new List<Customer> { };
        //reservations reservations = new reservations();
        public static void SignUp(string EmployeeName, int EmployeeSalary
            , string EmployeePhone,string EmployeeAdress, string UserName,string UserPassword,string EmployeeRoll)
        {
        
        

            if (EmployeePhone.Length == 11)

            {
                if (!string.IsNullOrEmpty(EmployeeName) && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserPassword) && !string.IsNullOrEmpty(EmployeeAdress) && EmployeeSalary != 0)
                {
                    Employee Emp = new Employee(EmployeeName, EmployeeSalary, EmployeePhone, EmployeeAdress, UserName, UserPassword, EmployeeRoll);
                    Employees.Add(Emp);
                    Employee User = new Employee(UserName,UserPassword, EmployeeRoll);
                    UserEmp.Add(User);

                }
                else { Console.WriteLine("there is a wrong sign up becouse you do not enter all requirements"); }
            }
            else
            {
                Console.WriteLine("Sorry Insert Invalid Phone Number Contain 11 number ");

            }
        }
        public void ShowUsersEmpData(string JsonFile)
        {
            WebRequest request = WebRequest.Create(JsonFile);
            WebResponse response = request.GetResponse();
            using (Stream datastream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(datastream);
                string responsefromserver = reader.ReadToEnd();
                // string json = File.ReadAllText(JsonFile);
                UserEmp = JsonConvert.DeserializeObject<List<Employee>>(responsefromserver);
                // OrderList.Add(order);
                foreach (var x in UserEmp)
                {


                    Console.WriteLine(x.UserName);
                    Console.WriteLine(x.UserPassword);
                    Console.WriteLine(x.UserRole);
                }
            }
        }
            public void ShowUsersEmpDataSignUp(string JsonFile)
            {
                WebRequest request = WebRequest.Create(JsonFile);
                WebResponse response = request.GetResponse();
                using (Stream datastream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(datastream);
                    string responsefromserver = reader.ReadToEnd();
                    // string json = File.ReadAllText(JsonFile);
                    Employees = JsonConvert.DeserializeObject<List<Employee>>(responsefromserver);
                    // OrderList.Add(order);
                    foreach (var x in Employees)
                    {
                        Console.WriteLine( x.EmpId);
                        Console.WriteLine(x.UserName);
                        Console.WriteLine( x.EmpSalary);
                        Console.WriteLine(x.PhoneNumber);
                        Console.WriteLine( x.Adress);
                        Console.WriteLine( x.UserName);
                        Console.WriteLine(  x.UserPassword);
                    }
                }
            }


        
        public void SaveSignUpIntoJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(Employees, Formatting.Indented);
            File.WriteAllText(JsonFile, json);

        }
        public void SaveIntoUsers(string JsonFile)
        {
            string jsonF = JsonConvert.SerializeObject(UserEmp, Formatting.Indented);
            File.WriteAllText(JsonFile, jsonF);

        }
    }
}
