
using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Restaurant_C__Project
{
    public class Waiter : Employee
    {
        public Waiter(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, UserRole) { }
        Reservations reserve = new reservations();
        OrderedItem orderitem = new ordereditem();
        public void ShowReservationList(int FromTime, int ToTime)     //done in main
        {
            reserve.ShowActiveReservatioList(FromTime, ToTime);
        }
        public void OrderCreation()
        {
            Console.WriteLine("enter the item ID you want to order");
            int ItemID = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the item quantity you want to order");
            int Quantity = int.Parse(Console.ReadLine());
            orderitem.CreateOrder(ItemID, Quantity);
        }
        public void showOrderToWaiter()
        {
            OrderedItem orderedItem = new OrderedItem();
            orderedItem.showOrderToWaiter();
        }
        public void TableReservation()
        {
            Console.WriteLine("enter table number you want to reserve");
            int tableNo=int.Parse(Console.ReadLine());
            Console.WriteLine("enter reservation time");
            int ReserveTime=int.Parse(Console.ReadLine());
            reserve.ReserveTable( tableNo,  ReserveTime);
           
        }
        public void ModifyReservation()
        {
            reserve.RemoveFromReservation();
        }
    }
}
