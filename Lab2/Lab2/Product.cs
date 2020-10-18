namespace Lab2
{
    public class Product
    {
        private int _productID;

        public int ProductID => _productID;

        private string _name;

        public string Name => _name;

        protected Product(int productId, string name)
        {
            _productID = productId;
            _name = name;
        }
        protected Product(Product product)
        {
            _productID = product.ProductID;
            _name = product.Name;
        }
    }
    
}