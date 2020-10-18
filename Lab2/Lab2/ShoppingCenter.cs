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
                // throw ex
            }
        }

        public void AddShop(Shop shop)
        {
            if (!CheckShopExistence(shop.ShopID))
            {
                _shops.Add(new Shop(shop));
            }
            else
            {
                // throw ex
            }
        }
    }
}