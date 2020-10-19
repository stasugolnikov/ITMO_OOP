using System;
using System.Collections.Generic;

namespace Lab2
{
    public class ShoppingCenter
    {
        private List<Shop> _shops;

        public ShoppingCenter()
        {
            _shops = new List<Shop>();
        }

        public ShoppingCenter(List<Shop> shops)
        {
            _shops = shops;
        }

        private bool CheckShopExistence(int shopID)
        {
            return _shops.Exists(shop => shop.ShopID == shopID);
        }

        public void AddShop(int shopID, string name, string adress)
        {
            if (!CheckShopExistence(shopID))
            {
                _shops.Add(new Shop(shopID, name, adress));
            }
            else
            {
                throw new ExistingShopIDException("Shop ID " + shopID + " already exists");
            }
        }

        public void AddShop(Shop shop)
        {
            if (!CheckShopExistence(shop.ShopID))
            {
                _shops.Add(shop);
            }
            else
            {
                throw new ExistingShopIDException("Shop ID " + shop.ShopID + " already exists");
            }
        }

        public Shop FindShopWithProductMinPrice(Product product)
        {
            int minPrice = Int32.MaxValue;
            var resShop = new Shop();
            foreach (var shop in _shops)
            {
                if (shop.TryGetProduct(product.ProductID, out var productItem) && productItem.Price < minPrice)
                {
                    minPrice = productItem.Price;
                    resShop = shop;
                }
            }

            return resShop;
        }

        public Shop FindShopWithMinTotalCostOfProducts(Dictionary<Product, int> ShoppingList)
        {
            int bestTotalCost = Int32.MaxValue;
            Shop resShop = null;
            foreach (var shop in _shops)
            {
                if (shop.TryBuyProductsList(ShoppingList, out var totalCost))
                {
                    if (totalCost < bestTotalCost)
                    {
                        bestTotalCost = totalCost;
                        resShop = shop;
                    }
                }
            }

            if (resShop != null)
            {
                return resShop;
            }

            throw new UnavaliableBuyProductList("Can not buy products");
        }
    }
}