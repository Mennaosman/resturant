namespace resturant
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Order order = new Order();

            //order.ShowOrdersList(@"C:\Users\M&M\source\repos\resturant\Order.Json");

            // order.Print();
            // order.AddToOrderList();
            //order.print();
            //Console.WriteLine(  "After");
            //order.RemoveFromOrder(2712405, 2040235);
            //order.print();
            //order.SaveOrderToJson(@"C:\Users\M&M\source\repos\resturant\Order.Json");
            //order.ClearOrderList();
            //order.print();
            Admin Admin = new Admin();
            Console.WriteLine("Please Enter Employee Name ");
            string EmployeeName = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Phone Number ");
            string EmployeePhone = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Salary ");
            int EmployeeSalary = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Adress ");
            string EmployeeAdress = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Username ");
            string UserName = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Password ");
            string Password = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Roll ");
            string EmployeeRoll = Console.ReadLine();
            Admin.ShowUsersEmpDataSignUp(@"C:\Users\M&M\source\repos\resturant\Employee.json");
            Admin.ShowUsersEmpData(@"C:\Users\M&M\source\repos\resturant\User.json
");
            Admin.SignUp(EmployeeName, EmployeeSalary, EmployeePhone, EmployeeAdress,
                UserName, Password, EmployeeRoll);
            Admin.SaveIntoUsers(@"C:\Users\M&M\source\repos\resturant\User.json");
            Admin.SaveSignUpIntoJson(@"C:\Users\M&M\source\repos\resturant\Employee.json");
        }
    }
}
