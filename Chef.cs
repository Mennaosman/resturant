
using Restaurant_C__Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_C__Project
{
    public class Chef : Employee
    {
        public Chef(int empId, int empSalary, string empName, string UserName, string UserPassword, string UserRole) : base(empId, empSalary, empName, UserName, UserPassword, UserRole) { }
        order order = new order();
        ingredients ingredients = new ingredients();
        public void ShowOrderList(string JsonFile)
        {
            Order.ShowOrdersList(string JsonFile);
        }
        public void FinishOrder()
        {
            Order.RemoveFromOrder();
        }
        public void ShowStock()
        {
            Stock.Get_Instance().ShowListOfIngredients();
            
        }
        public void RequestIngredient(int ingredientId , int ingredientQuantity)
        {
            Stock.Get_Instance().IngredientToChef(int ingredientId, int ingredientQuantity)///where
        }




    }
}
