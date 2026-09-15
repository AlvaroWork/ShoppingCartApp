using ShoppingCartApp.Controllers;
using ShoppingCartApp.Models;

namespace FillTest
{
    [TestClass]
    public sealed class ShoppingCartControllerTest
    {
        [TestMethod]
        public void FillShoppingCart_ItemCanBeAdded()
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemsList = new List<Item>()
            };

            ShoppingCartController shoppingCartController = new ShoppingCartController();

            List<Item> items = new List<Item>
            {
                new Item { Name = "Item1", Weight = 2.0f }
            };

            ShoppingCart result = shoppingCartController.FillShoppingCart(items, shoppingCart, 0f);

            Assert.AreEqual(1, result.ItemsList.Count);
            Assert.AreEqual(2.0f, result.ActualLoadedWeight);
        }

        [TestMethod]
        public void FillShoppingCart_ItemCannotBeAdded()
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemsList = new List<Item>()
            };
            ShoppingCartController shoppingCartController = new ShoppingCartController();
            List<Item> items = new List<Item>
            {
                new Item { Name = "Item1", Weight = 30.0f }
            };
            ShoppingCart result = shoppingCartController.FillShoppingCart(items, shoppingCart, 0f);
            Assert.AreEqual(0, result.ItemsList.Count);
            Assert.AreEqual(0f, result.ActualLoadedWeight);
        }


        [TestMethod]
        public void FillShoppingCart_MultipleItems_AllItemsAdded()
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemsList = new List<Item>()
            };
            ShoppingCartController shoppingCartController = new ShoppingCartController();
            List<Item> items = new List<Item>
            {
                new Item { Name = "Item1", Weight = 4.0f },
                new Item { Name = "Item2", Weight = 3.0f },
                new Item { Name = "Item3", Weight = 2.0f }
            };
            ShoppingCart result = shoppingCartController.FillShoppingCart(items, shoppingCart, 0f);
            Assert.AreEqual(3, result.ItemsList.Count);
            Assert.AreEqual(9.0f, result.ActualLoadedWeight);
        }

        [TestMethod]
        public void FillShoppingCart_MultipleItems_SomeItemsCannotBeAdded()
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemsList = new List<Item>()
            };
            ShoppingCartController shoppingCartController = new ShoppingCartController();
            List<Item> items = new List<Item>
            {
                new Item { Name = "Item1", Weight = 15.0f },
                new Item { Name = "Item2", Weight = 10.0f },
                new Item { Name = "Item3", Weight = 7.0f },
                new Item { Name = "Item4", Weight = 3.0f }
            };
            ShoppingCart result = shoppingCartController.FillShoppingCart(items, shoppingCart, 0f);
            Assert.AreEqual(2, result.ItemsList.Count);
            Assert.AreEqual(18.0f, result.ActualLoadedWeight);
        }

        [TestMethod]
        public void FillShoppingCart_ExactItemFits_ItemAddedToCart()
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ItemsList = new List<Item>()
            };
            ShoppingCartController shoppingCartController    = new ShoppingCartController();
            List<Item> items = new List<Item>
            {
                new Item { Name = "Item1", Weight = 20.0f }
            };
            ShoppingCart result = shoppingCartController.FillShoppingCart(items, shoppingCart, 0f);
            Assert.AreEqual(1, result.ItemsList.Count);
            Assert.AreEqual(20.0f, result.ActualLoadedWeight);

        }
    }
}
