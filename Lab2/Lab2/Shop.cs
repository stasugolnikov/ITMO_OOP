using System.Collections.Generic;

namespace Lab2
{
    public class Shop
    {
        private List<ProductItem> _productItems;

        private List<ProductItem> ProductItems => _productItems;

        private int _shopID;

        public int ShopID => _shopID;

        private string _name;

        public string Name => _name;

        private string _adress;

        public string Adress => _adress;

        public Shop(int shopID, string name, string adress)
        {
            _shopID = shopID;
            _name = name;
            _adress = adress;
            _productItems = ProductItems;
        }

        public Shop(Shop shop)
        {
            _shopID = shop.ShopID;
            _name = shop.Name;
            _adress = shop.Adress;
            _productItems = new List<ProductItem>();
        }

        private bool CheckProductExistence(int productID)
        {
            return _productItems.Exists(product => product.ProductID == productID);
        }

        public void AddProduct(int productID, string name)
        {
            if (!CheckProductExistence(productID))
            {
                _productItems.Add(new ProductItem(productID, name));
            }
            else
            {
                // throw ex
            }
        }

        public void AddProduct(Product product)
        {
            if (!CheckProductExistence(product.ProductID))
            {
                _productItems.Add(new ProductItem(product));
            }
            else
            {
                // throw ex
            }
        }

        public void DeliverProducts(int productID, int price, int amount)
        {
            if (!CheckProductExistence(productID))
            {
                // throw ex
            }

            int pos = _productItems.FindIndex(product => product.ProductID == productID);
            _productItems[pos].Price = price;
            _productItems[pos].Amount = amount;
        }

        public void DeliverProducts(Product product, int price, int amount)
        {
            if (!CheckProductExistence(product.ProductID))
            {
                // throw ex
            }

            int pos = _productItems.FindIndex(productItem => productItem.ProductID == product.ProductID);
            _productItems[pos].Price = price;
            _productItems[pos].Amount = amount;
        }
    }
}