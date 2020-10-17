namespace Lab2
{
    public class Product 
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

        protected Product()
        {
            _productID = default;
            _name = default;
        }
        
        public Product(int productID, string name)
        {
            _productID = productID;
            _name = name;
        }
    }
}