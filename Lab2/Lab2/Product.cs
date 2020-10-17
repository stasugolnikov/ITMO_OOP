namespace Lab2
{
    class Product
    {
        private int _productID;

        public int ProductID
        {
            get => _productID;
        }

        private string _name;

        public string Name
        {
            get => _name;
        }

        protected Product(Product product)
        {
            _productID = product.ProductID;
            _name = product.Name;
        }

        public Product(int productID, string name)
        {
            _productID = productID;
            _name = name;
        }

        public static Product Create(int productID, string name)
        {
            return new Product(productID, name);
        }
    }
}