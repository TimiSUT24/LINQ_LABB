using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_LABB
{
    public static class Menu
    {
        public static void ShowMenu()
        {
            Console.Clear();

            Dictionary<string, Action> Menu = new Dictionary<string, Action>()
            {
                { "1", () => {MethodSyntax.Electronics(); } },
                { "2", () => {MethodSyntax.Suppliers(); } },
                { "3", () => {MethodSyntax.TotalOrderValue(); } },
                { "4", () => {MethodSyntax.MostSoldProducts(); } },
                { "5", () => {MethodSyntax.ListAllCategories(); } },
                { "6", () => {MethodSyntax.GetAllOrders(); } }


            };

            while (true)
            {
                Console.WriteLine("Välj ett alternativ:\n");
                Console.WriteLine("1. Electronics\n" +
                    "2. Suppliers\n" +
                    "3. Total order value\n" +
                    "4. Most sold products\n" +
                    "5. List all categories\n" +
                    "6. Get all orders\n" +                  
                    "0. Exit");


                string Input = Console.ReadLine();

                if(Menu.ContainsKey(Input))
                {
                    Menu[Input].Invoke();
                }
                else
                {
                    if (Input == "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Closing program...");
                        break;                       
                    }
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
               
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }           
        }

    }
}
