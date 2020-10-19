namespace Lab2
{
    public class Product
    {
        public int ProductID { get; }

        public string Name { get; }

        public Product(int productId, string name)
        {
            ProductID = productId;
            Name = name;
        }
        protected Product(Product product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
        }
    }
    
}