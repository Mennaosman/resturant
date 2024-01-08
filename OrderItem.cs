using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resturant
{
    internal class OrderItem
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        public List<int> ItemIdAndQuantities { get; set; }
        //public List<int> ItemPrice { get; set; }
        public OrderItem() {
            this.ItemId = ItemId;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public OrderItem(int ItemId, int Quantity,int Price)
        {
            //Random R = new Random();
            //this.ItemId = R.Next();
            this.ItemId = ItemId;
            this.Quantity = Quantity;
            this.Price = Price;
        }
       /* public void CreateOrder(int ItemID, int Quantity)
        {
            ItemIdAndQuantities.AddRange(new List<int> { ItemID, Quantity });
            foreach (var item in ItemIdAndQuantities)
            {
                Console.WriteLine(item);
            }
        }
        /*
        public void Printing(int ItemID, int Quantity, int Price)
        {
            ItemPrice.AddRange(new List<int> { ItemID, Quantity, Price });
            int TotalPrice = 0;
            foreach (var item in ItemPrice)
            {
                TotalPrice += Quantity * Price;
                Console.WriteLine(item + "Total Price is " + TotalPrice);
            }


        }
        */
    }
}
