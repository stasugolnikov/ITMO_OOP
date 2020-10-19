using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Lab2;

namespace Tests
{
    public class Tests
    {
        Product camera = new Product(121, "camera");
        Product headphones = new Product(122, "headphones");
        Product tv = new Product(123, "tv");
        Product computer = new Product(124, "computer");
        Product keyboard = new Product(125, "keyboard");
        Product smartphone = new Product(126, "smartphone");
        Product monitor = new Product(127, "monitor");
        Product watch = new Product(128, "watch");
        Product tablet = new Product(129, "tablet");
        Product ssd = new Product(130, "ssd");

        Shop mvideo = new Shop(1, "mvideo", "rostov");
        Shop dns = new Shop(2, "dns", "spb");
        Shop citilink = new Shop(3, "citilink", "msk");

        ShoppingCenter sc = new ShoppingCenter();

        public Tests()
        {
            dns.AddProduct(tv, 50000, 10);
            mvideo.AddProduct(tv, 40000, 10);
            mvideo.DeliverProducts(tv, 40000, 9);
            dns.AddProduct(computer, 100000, 10);
            citilink.AddProduct(keyboard, 2000, 7);
            citilink.DeliverProducts(keyboard, 2000, 10);
            dns.AddProduct(ssd, 4000, 4);
            dns.DeliverProducts(ssd, 4000, 8);
            mvideo.AddProduct(ssd, 5000, 10);
            citilink.AddProduct(watch, 7000, 10);
            dns.AddProduct(camera, 5000, 40);
            citilink.AddProduct(camera, 7500, 10);
            mvideo.AddProduct(monitor, 7000, 15);
            dns.AddProduct(monitor, 8000, 20);
            citilink.AddProduct(tablet, 9000, 10);
            mvideo.AddProduct(tablet, 10000, 4);
            citilink.AddProduct(headphones, 2000, 10);
            mvideo.AddProduct(headphones, 1900, 15);
            dns.AddProduct(smartphone, 10000, 10);
            mvideo.AddProduct(smartphone, 9000, 8);
            citilink.AddProduct(smartphone, 12000, 20);

            sc.AddShop(mvideo);
            sc.AddShop(dns);
            sc.AddShop(citilink);
        }

        [Test]
        public void TestFindShopWithProductMinPrice()
        {
            Assert.AreEqual(1, sc.FindShopWithProductMinPrice(tv).ShopID);
            Assert.AreEqual(3, sc.FindShopWithProductMinPrice(keyboard).ShopID);
            Assert.AreEqual(2, sc.FindShopWithProductMinPrice(ssd).ShopID);
        }

        [Test]
        public void TestBuyProduct()
        {
            Assert.AreEqual(300000, dns.BuyProduct(computer, 3));
            Assert.AreEqual(15000, citilink.BuyProduct(camera, 2));
        }

        [Test]
        public void TestFindShopWithMinTotalCostOfProducts()
        {
            var shoppingList1 = new Dictionary<Product, int>()
            {
                [computer] = 1,
                [monitor] = 2
            };
            var shoppingList2 = new Dictionary<Product, int>()
            {
                [headphones] = 1,
                [keyboard] = 1
            };
            var shoppingList3 = new Dictionary<Product, int>()
            {
                [ssd] = 1,
                [monitor] = 1
            };
            Assert.AreEqual(2, sc.FindShopWithMinTotalCostOfProducts(shoppingList1).ShopID);
            Assert.AreEqual(3, sc.FindShopWithMinTotalCostOfProducts(shoppingList2).ShopID);
            Assert.AreEqual(1, sc.FindShopWithMinTotalCostOfProducts(shoppingList3).ShopID);
        }


        private bool CompareLists(List<ProductItem> list1, List<ProductItem> list2)
        {
            foreach (var productItem in list1)
            {
                int pos = list1.FindIndex(product =>
                    productItem.ProductID == product.ProductID && productItem.Amount == product.Amount);
                if (pos == -1)
                {
                    return false;
                }
            }

            return true;
        }


        [Test]
        public void TestWhatProductCanBeBought()
        {
            var list1 = new List<ProductItem>
            {
                new ProductItem(ssd, 4000, 2),
                new ProductItem(camera, 5000, 2),
                new ProductItem(monitor, 8000, 1),
                new ProductItem(smartphone, 10000, 1)
            };
            var list2 = dns.WhatProductCanBeBought(10000);
            Assert.AreEqual(true, CompareLists(list1, list2));
        }
    }
}