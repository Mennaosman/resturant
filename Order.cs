using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace resturant
{
    internal class Order
    {
        public int OrderId { get; set; }
        public double OrderPrice { get; set; }
        public string CustomerId { get; set; }
        public  List<OrderItem> ListItem { get; } = new List<OrderItem>{ };
        public static List<Order> ActiveOderList = new List<Order> { };
        public static List<Order> OrderList = new List<Order> { };
        public static List<Order> WaitingOrderList = new List<Order> { };
        public Order()
        {
           // OrderId = 0;
           // ListItem = null;

        }
        public static void ShowActiveOderList()
        {
            
        }
        public Order(List<OrderItem> Items)
        {
            Random R = new Random();
            this.OrderId = R.Next(); 
            this.OrderId = OrderId;
            this.ListItem = Items;
            double TotalPrice=0;
            foreach (var x in ListItem)
            {
                TotalPrice += x.Quantity * x.Price;
            }
            this.OrderPrice = TotalPrice;
        }
        public void AddToOrderList()
        {
            /*
                        if (ActiveOderList.Count < 10 )
                        {
                            OrderList.Add(this);
                            ActiveOderList.Add(this);
                        }

                        else
                            WaitingOrderList.Add(this);
            */
            OrderItem Item = new OrderItem(2042235, 3, 60);
            OrderItem Item2 = new OrderItem(2040235, 7, 40);
            ListItem.Add(Item);
            ListItem.Add(Item2);
            for (int i = 1; i < 3; i++)
            {
                
                Order order = new Order(ListItem);
                OrderList.Add(order);
            }
            //OrderList.Add(json);
        }
        public void RmoveFromWaitingList()
        {
            for(int i=WaitingOrderList.Count;i>=WaitingOrderList.Count;i--)
            {
                WaitingOrderList.Remove(WaitingOrderList[i]);
                ActiveOderList.Add(WaitingOrderList[i]);

            }
        }
        public void ShowOrdersList(string JsonFile)
        {
            WebRequest request = WebRequest.Create(JsonFile);
            WebResponse response = request.GetResponse();
            using (Stream datastream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(datastream);
                string responsefromserver = reader.ReadToEnd();
               // string json = File.ReadAllText(JsonFile);
                OrderList = JsonConvert.DeserializeObject<List<Order>>(responsefromserver);
                // OrderList.Add(order);
                foreach (var x in OrderList)
                {
                    Console.WriteLine(x.OrderId);
                    Console.WriteLine(x.OrderPrice);
                    Console.WriteLine(x.CustomerId);
                    foreach (var y in x.ListItem)
                    {
                        //foreach()
                        Console.WriteLine(y.ItemId);
                        Console.WriteLine(y.Quantity);
                        Console.WriteLine(y.Price);
                    }
                }
            }
           // Console.ReadKey();


        }
      
        public void RemoveFromOrder(int OrderId,int ItemId)
        {
            foreach (var x in OrderList)
             {
                if(x.OrderId==OrderId)
               
                foreach (var y in x.ListItem)
                {
                        if (y.ItemId == ItemId)
                        {
                            ListItem.Remove(y);
                            Console.WriteLine("sucssesfully removed");
                            x.OrderPrice = x.OrderPrice - (y.Price * y.Quantity);

                            Console.WriteLine(x.OrderPrice);
                        }
                }
                
            }
        }
        public void print()
        {if (OrderList.Count==0)
            {
                Console.WriteLine("No Orders To Show");
            }
            else
            {
                foreach (var x in OrderList)
                {
                    Console.WriteLine(x.OrderId);
                    Console.WriteLine(x.OrderPrice);
                    Console.WriteLine(x.CustomerId);
                    foreach (var y in x.ListItem)
                    {

                        Console.WriteLine(y.ItemId);
                        Console.WriteLine(y.Quantity);
                        Console.WriteLine(y.Price);
                    }
                }
            }
        }
      public void ClearOrderList()
        {
            OrderList.Clear();
            Console.WriteLine( "All Orders removed sucssesfully");
        }
        public void DeleteOrderFromOrderList(int OrderIdToDelete)
        {
            foreach(var Order in OrderList)
            {
                if(Order.OrderId== OrderIdToDelete)
                    {
                    OrderList.Remove(Order);
                }
            }
            
        }
       
        public  void SaveOrderToJson(string JsonFile)
        {
            string json = JsonConvert.SerializeObject(OrderList, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
    }
}
