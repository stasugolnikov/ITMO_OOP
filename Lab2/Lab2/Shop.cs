using System.Collections.Generic;

namespace Lab2
{
    public class Shop
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

        private List<ProductItem> _productItems;

        public Shop(int id, string name)
        {
            _shopID = id;
            _name = name;
            _productItems = new List<ProductItem>();
        }

        private bool CheckProductExistence(int id)
        {
            return _productItems.Exists(product => { return product.ProductID == id; });
        }

        public void CreateProduct(int id, string name)
        {
            if (!CheckProductExistence(id))
            {
                _productItems.Add(new ProductItem(id, name));
            }
            else
            {
                // throw ex
            }
        }

        public void DeliverProducts(int id, int price, int amount)
        {
            if (CheckProductExistence(id))
            {
                int pos = _productItems.FindIndex(product => { return product.ProductID == id; });
                _productItems[pos].Amount = amount;
                _productItems[pos].Price = price;
            }
            else
            {
                // throw ex
            }
        }
    }
}