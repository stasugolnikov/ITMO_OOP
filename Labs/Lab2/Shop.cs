using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Shop
    {
        private List<ProductItem> _productItems;

        public List<ProductItem> ProductItems => _productItems;
        
        public int ShopID { get; }

        public string Name { get; }

        public string Adress { get; }

        public Shop(int shopID, string name, string adress)
        {
            ShopID = shopID;
            Name = name;
            Adress = adress;
            _productItems = new List<ProductItem>();
        }

        public Shop()
        {
            ShopID = default;
            Name = default;
            Adress = default;
            _productItems = new List<ProductItem>();
        }

        private bool CheckProductExistence(int productID)
        {
            return _productItems.Exists(product => product.ProductID == productID);
        }

        public void AddProduct(Product product, int price, int amount = 0)
        {
            if (!CheckProductExistence(product.ProductID))
            {
                _productItems.Add(new ProductItem(product, price, amount));
            }
            else
            {
                throw new ExistingProductIDException("Product ID " + product.ProductID + " already exists");
            }
        }

        public void DeliverProducts(int productID, int price, int amount)
        {
            if (!CheckProductExistence(productID))
            {
                throw new NotExistingProductIDException("Product ID " + productID + " do not exists");
            }

            int pos = _productItems.FindIndex(product => product.ProductID == productID);
            _productItems[pos].Price = price;
            _productItems[pos].Amount += amount;
        }

        public void DeliverProducts(Product product, int price, int amount)
        {
            if (!CheckProductExistence(product.ProductID))
            {
                throw new NotExistingProductIDException("Product ID " + product.ProductID + " do not exists");
            }

            int pos = _productItems.FindIndex(productItem => productItem.ProductID == product.ProductID);
            _productItems[pos].Price = price;
            _productItems[pos].Amount += amount;
        }

        public bool TryGetProduct(int productID, out ProductItem product)
        {
            if (CheckProductExistence(productID))
            {
                product = _productItems.Find(p => p.ProductID == productID);
                return true;
            }

            product = default;
            return false;
        }

        public List<ProductItem> WhatProductCanBeBought(int moneyAmount)
        {
            var productItems = new List<ProductItem>();
            int pos = 0;
            foreach (var productItem in _productItems)
            {
                int amount = 0;
                int money = moneyAmount;
                int ProductAmount = productItem.Amount;
                while (money >= productItem.Price && ProductAmount > 0)
                {
                    amount++;
                    money -= productItem.Price;
                    ProductAmount--;
                }

                if (amount > 0)
                {
                    productItems.Add(productItem);
                    productItems[pos].Amount = amount;
                    pos++;
                }
            }

            return productItems;
        }

        private bool TryBuyProduct(Product product, int amount, out int totalCost)
        {
            int pos = _productItems.FindIndex(productItem => productItem.ProductID == product.ProductID);
            if (pos != -1)
            {
                if (_productItems[pos].Amount < amount)
                {
                    totalCost = default;
                    return false;
                }
                else
                {
                    totalCost = amount * _productItems[pos].Price;
                    return true;
                }
            }

            totalCost = default;
            return false;
        }

        public int BuyProduct(Product product, int amount)
        {
            if (!TryBuyProduct(product, amount, out var totalCost))
            {
                throw new UnavaliableProduct("Can not buy product " + product.ProductID + " in amount" + amount);
            }

            return totalCost;
        }

        public bool TryBuyProductsList(Dictionary<Product, int> ShoppingList, out int total)
        {
            int resTotalCost = 0;
            foreach (var item in ShoppingList)
            {
                if (!TryBuyProduct(item.Key, item.Value, out var totalCost))
                {
                    total = default;
                    return false;
                }
                resTotalCost += totalCost;
            }

            total = resTotalCost;
            return true;
        }
    }
}