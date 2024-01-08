using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resturant
{
    internal class Menu
    {
        /*
        private static Menu menu_instance;
        private static List<Item> AllItems = new List<Item>();
        private Menu()
        {
        }
        public static Menu GetInstance()
        {
            if (menu_instance == null)
                menu_instance = new Menu();
            return menu_instance;
        }
        public static void LoadAllItemsFromJson(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                AllItems = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
        public static void SaveItemsToFile(string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(AllItems, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
        public void ShowItems()
        {
            foreach (var MenuItems in AllItems)
            {
                Console.WriteLine($"item ID           : {MenuItems.ItemID}  ");
                Console.WriteLine($"item name         : {MenuItems.ItemName}  ");
                Console.WriteLine($"item price        : {MenuItems.ItemPrice}  ");
                Console.WriteLine($"item description  : {MenuItems.description}   ");
                Console.WriteLine($"item category     : {MenuItems.category}   ");
                Console.WriteLine("Recipe :");
                foreach (var Ingred in MenuItems.recipe)
                {
                    Console.WriteLine($"    Ingredient ID       : {Ingred.IngredientID}");
                    Console.WriteLine($"    Ingredient Quantity : {Ingred.ItemIngredientQuantity}");
                }
                Console.WriteLine();
                Console.WriteLine("******************************************************************");
            }
        }

        public void Showitemstocustomer()
        {
            foreach (var MenuItems in AllItems)
            {
                Console.WriteLine($"item ID           : {MenuItems.ItemID}  ");
                Console.WriteLine($"item name         : {MenuItems.ItemName}  ");
                Console.WriteLine($"item price        : {MenuItems.ItemPrice}  ");
                Console.WriteLine($"item description  : {MenuItems.description}   ");
                Console.WriteLine($"item category     : {MenuItems.category}   ");
                Console.WriteLine("******************************************************************");
            }
        }

        public void AddItem(string NewItemName, int NewItemPrice, int NewItemID, string NewDescription)
        {
            AllItems.Add(new Item
            { ItemName = NewItemName, ItemPrice = NewItemPrice, ItemID = NewItemID, description = NewDescription });
        }

        public void RemoveItem(int deleteItemID)
        {
            foreach (var x in AllItems)
            {
                if (x.ItemID == deleteItemID)
                {
                    AllItems.Remove(x);
                }
            }
        }
        */
    }
}
