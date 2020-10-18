namespace Lab2
{
    public class ProductItem : Product
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

        public ProductItem(int productID, string name) : base(productID, name)
        {
            _price = default;
            _amount = default;
        }
        
        public ProductItem(Product product) : base(product)
        {
            _price = default;
            _amount = default;
        }
        
    }
}