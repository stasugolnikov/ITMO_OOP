using System;
using System.Collections.Generic;

namespace Lab2
{
    class Shop
    {
        private int _shopID;

        public int ShopID
        {
            get => _shopID;
        }

        private string _name;

        public string Name
        {
            get => _name;
        }

        private List<Product> _products;

        public Shop(int id, string name)
        {
            _shopID = id;
            _name = name;
            _products = new List<Product>();
        }

        private bool CheckProductExistence(Product product)
        {
            return _products.Exists(tmp => { return product.ProductID == tmp.ProductID; });
        }

        public void DeliverProducts(Product product, int price, int amount)
        {
            if (!CheckProductExistence(product))
            {
                _products.Add(new ProductItem(product, price, amount));
            }
            else
            {
                //throw ex
            }
        }
    }
}