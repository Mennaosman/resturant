
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal class Cashier : Employee
    {
        OrderedItem ordereditem = new OrderedItem();
        public Cashier(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, "Cashier") { }
        public void PrintInvoice()
        {
            ordereditem.Printing();
        }
    }
}
