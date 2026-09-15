using System.Text.Json;
using System.IO;
using ShoppingCartApp.Models;
using ShoppingCartApp.Controllers;

namespace ShoppingCartApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // We prepare a new shopping cart and set actual weight to 0 theen initialize the shopping cart controller
            ShoppingCart ShoppingCart = new ShoppingCart
            {
                ItemsList = new List<Item>()
            };
            float actualWeight = 0;

            ShoppingCartController shoppingCartController = new ShoppingCartController();

            //Interface for the user to select a list of items 
            Console.WriteLine("Welcome to the shopping cart application.");
            Console.WriteLine("Select a list of items:");
            Console.WriteLine("1. Light Shopping List");
            Console.WriteLine("2. Heavy Shopping List");
            Console.WriteLine("3. Medium Shopping List");

            Console.WriteLine("Enter the number of the list you want to select: ");
            string? option = Console.ReadLine();

            // Reading of the Json Files that are the itemsList and deserializing them into a list of items ordered by weight in descending order.
            string json = option switch
            {
                "1" => File.ReadAllText("ShoppingList/LightShoppingList.json"),
                "2" => File.ReadAllText("ShoppingList/HeavyShoppingList.json"),
                "3" => File.ReadAllText("ShoppingList/MediumShoppingList.json"),
                _ => throw new ArgumentException("Invalid option")
            };

            List<Item>? items = JsonSerializer
                .Deserialize<List<Item>>(json)?
                .OrderByDescending(a => a.Weight)
                .ToList();

            //We call the method that will fill the shoppingCart
            ShoppingCart = shoppingCartController.FillShoppingCart(items, ShoppingCart, actualWeight);



            //Print the list of items with their weights that are in the soppping cart ,in addition we print  the total weight of the cart
            foreach (Item item in ShoppingCart.ItemsList)
            {
                Console.WriteLine($"Name: {item.Name} - Weight: {item.Weight} kg");
            }
            Console.WriteLine($"Total weight of the cart: {ShoppingCart.ActualLoadedWeight} kg");
        }
    }
}
