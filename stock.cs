using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    internal sealed class Stock
    {
        public static List<Ingredient> AllItems = new List<Ingredient>();
        private static Stock MyStock;
   

        private Stock() { }
        public static Stock Get_Instance()
        {
            if (MyStock == null)
                MyStock = new Stock();
            return MyStock;
        }



        public static void LoadAllItemsFromJson(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                AllItems = JsonConvert.DeserializeObject<List<Ingredient>>(json);
            }
        }
        public static void SaveItemsToFile(string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(AllItems, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
        public void ShowListOfIngredients()
        {
            foreach (var x in AllItems)
            {
                Console.WriteLine($"Ingredient ID        : {x.IngredientID}");
                Console.WriteLine($"Ingredient Name      : {x.IngredientName}");
                Console.WriteLine($"Ingredient Status    : {x.IngredientStatus}");
                Console.WriteLine($"Ingredient Quantity  : {x.IngredientQuantity}");
                Console.WriteLine("********************************************************");
            }
        }
        public void CheckAvailability(int CheckIngredientID)
        {
            bool condition = false;
            foreach (var x in AllItems)
            {
                if (CheckIngredientID == x.IngredientID)
                {
                    condition = true;
                    //break;
                    Console.WriteLine($"{x.IngredientName} is available by {x.IngredientQuantity}");
                }
            }
            if (condition == false)
            {
                Console.WriteLine("enter ingredient id , ingredient name and ingredient quantity");
                int ingredientID = int.Parse(Console.ReadLine());
               string ingredientname = Console.ReadLine();
                int quantity = int.Parse(Console.ReadLine());
                AddIngredient(ingredientID, ingredientname, quantity);
            }
        }

        public void AddIngredient(int IngredientID, string IngredientName, int IngredientQuantity)
        {
            bool IsIngredientInStock = false;
            foreach (var x in AllItems)
            {
                if (IngredientID == x.IngredientID)
                    IsIngredientInStock = true;
                Console.WriteLine("this ingredient is already in the stock");
            }
            if (IsIngredientInStock == false)
            {
                AllItems.Add(
                    new Ingredient
                    {
                        IngredientID = IngredientID, IngredientName = IngredientName,IngredientStatus = true,
                        IngredientQuantity = IngredientQuantity
                    });
            }
        }
      public void IngredientToChef(int ingredientId, int ingredientQuantity)
        {
            bool isAvailable=false;
            foreach (var x in AllItems)
            {
                if (ingredientId == x.IngredientID && x.IngredientQuantity >= ingredientQuantity) {
                    isAvailable = true;
                    x.IngredientQuantity = (x.IngredientQuantity) - (1 * ingredientQuantity);
                    Console.WriteLine($"ingredient with ID {ingredientId} transfered to chef by quantity {ingredientQuantity}");
                }
                else if (ingredientId == x.IngredientID && x.IngredientQuantity < ingredientQuantity)
                {
                    Console.WriteLine($"ingredient with ID {ingredientId} is not available by quantity {ingredientQuantity} in stock")
                }
            }
            if(isAvailable == false) {
                Console.WriteLine($"ingredient with ID {ingredientId} is not available in stock");
            }
        }

    }
}
