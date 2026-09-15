using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models
{
    public class ShoppingCart
    {
        public List<Item> ItemsList {  get; set; }

       public  float MaxWeight { get; set; } = 20f;

        public float ActualLoadedWeight { get; set; } = 0f;
    }
}
