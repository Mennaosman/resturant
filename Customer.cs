using Newtonsoft.Json;

namespace Restaurant_C__Project
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }

        public string UserPassword { get; set; }
        public int Balance { get; set; }
        public static List<Customer> AllCustomer = new List<Customer> { };

        public Customer(string Fullname, string Phonenumber, string Address, string username, string password)
        {
            Balance = 0;
            FullName = Fullname;
            PhoneNumber = Phonenumber;
            this.Address = Address;
            UserName = username;
            UserPassword = password;
            CustomerId = UserName + UserPassword;
        }

        public void CreateOrder(string orderjsonpath)
        {
            Console.WriteLine("May I take your order now?");
            bool endorder = false;
            List<OrderedItem> items = new List<OrderedItem>();
            while (endorder == false)
            {
                Console.WriteLine("Please enter the ID of the item you want to order from the menu above.");
                int itemid = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the quantity of the item you want to order.");
                int quantity = int.Parse(Console.ReadLine());
                Console.Clear();
                int itemprice = Menu.GetInstance().GetItemPrice(itemid);
                int itemtotalprice = itemprice * quantity;
                OrderedItem item = new OrderedItem(itemid, quantity, itemtotalprice);
                items.Add(item);
            orderloop:
                Console.WriteLine("1: I'd like to add more items");
                Console.WriteLine("2: I want to cancel an item I've ordered");
                Console.WriteLine("3: I want to procced with current order.");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Please enter the ID of the item you want to cancel.");
                        int cancelid = int.Parse(Console.ReadLine());
                        foreach (var x in items)
                        {
                            if (x.ItemID == cancelid)
                            {
                                items.Remove(x);
                                break;
                            }
                        }
                        goto orderloop;
                    case 3:
                        if (Balance < itemtotalprice)
                        {
                            Console.WriteLine("Sorry, you don't have enough funds to complete this order.");
                            Console.WriteLine("Do you wish to top up?");
                            Console.WriteLine("1: Yes, I want to top up and Process with my order.");
                            Console.WriteLine("2: No, Cancel my order.");
                            int TopUp = int.Parse(Console.ReadLine());
                            if (TopUp == 1)
                            {
                                addToBalance();
                                Console.WriteLine("Your order has been placed successfully.");
                                Balance = Balance - itemtotalprice;
                            }
                            else
                            {
                                Console.WriteLine("Your order has been cancelled.");
                                foreach (var x in items)
                                {
                                    items.Remove(x);
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("Your delicious order is being prepared at the moment.");
                        break;
                }
                double totalorderprice = 0;
                foreach (var x in items)
                {
                    totalorderprice += x.Price;
                }
                Order order = new Order(totalorderprice, CustomerId, items);
                Order.LoadOrderFromJson(orderjsonpath);
                order.AddToOrderList();
                Order.SaveOrderToJson(orderjsonpath);
                Customer.ShowNotification("Order");
            }
        }
        public void addToBalance()
        {
            Console.WriteLine($"Hi {FullName}, your account balance is currently at {Balance}. Consider adding more funds to avoid any issues.");
            int addedbalance = int.Parse(Console.ReadLine());
            Balance = Balance + addedbalance;
            Console.WriteLine($"Success! an amount of {addedbalance} has been added to your account.");
        }
        public static void ShowNotification(string service)
        {
            switch (service)
            {
                case "Order":
                    Console.WriteLine("Thank you for your order from [Restaurant Name]! We're busy preparing your delicious food");
                    break;
                case "Reservation":
                    Console.WriteLine("Your table at [Restaurant Name] is waiting!");
                    break;
                default:
                    Console.WriteLine("Error: Invalid service.");
                    break;
            }
        }
        public static void LoadAllCustomersFromJson(string jsonFilePath)
        {
            if (System.IO.File.Exists(jsonFilePath))
            {
                string json = System.IO.File.ReadAllText(jsonFilePath);
                AllCustomer = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }
        public void AddCustomer()
        {
            AllCustomer.Add(this);
        }
        public static Customer VerifyCustomer(string username, string password)
        {
            foreach (Customer customer in AllCustomer)
            {
                if (customer.UserName == username && customer.UserPassword == password)
                {
                    return customer;
                }
            }
            return null;
        }
        public static void SaveCustomersToFile(string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(AllCustomer, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, json);
        }
        //public static Customer FindCustomer(string username, string password)
        //{
        //    foreach (Customer customer in AllCustomer)
        //    {
        //        if (customer.UserName == username && customer.UserPassword == password)
        //        {
        //            return customer;
        //        }
        //    }
        //    return null;
        //}
    }
}