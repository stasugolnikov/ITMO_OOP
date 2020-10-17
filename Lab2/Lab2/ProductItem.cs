namespace Lab2
{
    class ProductItem : Product
    {
        private int _price;

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        private int _amount;

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public ProductItem(Product product, int price, int amount) : base(product)
        {
            _price = price;
            _amount = amount;
        }

        public ProductItem(int productID, string name) : base(productID, name)
        {
            _price = default;
            _amount = default;
        }
    }
}