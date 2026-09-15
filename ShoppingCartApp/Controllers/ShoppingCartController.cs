using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Controllers
{
    public class ShoppingCartController
    {

        // method to fill the shopping cart with items without exceeding the maximum weight
        public ShoppingCart FillShoppingCart(List<Item> items, ShoppingCart shoppingCart, float actualWeight)
        {
            foreach (Item item in items)
            {
                // Check if adding the item would exceed the maximum weight
                if (actualWeight + item.Weight <= shoppingCart.MaxWeight)
                {
                    //we add the item to the shopping cart and update the actual weight
                    shoppingCart.ItemsList.Add(item);
                    actualWeight += item.Weight;
                    Console.WriteLine($"Item '{item.Name}'with weight: {item.Weight} kg added to cart. Actual weight: {actualWeight} kg");
                }
                else
                {
                    // in cae the item cannot be added because it would exceed the maximum weight, we print a message
                    Console.WriteLine($"Item  '{item.Name}' with weight: {item.Weight} kg cannot be added to cart. It would exceed the maximum allowed weight.");
                }
            }
            // updated the loaded weight of the shopping cart
            shoppingCart.ActualLoadedWeight = actualWeight;
            return shoppingCart;
        }
    }
}
 