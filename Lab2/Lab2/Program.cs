using System;


namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product bread = Product.Create(13,"bread");
            Product cheese = Product.Create(14,"cheese");
            Shop shop = new Shop(228,"magaz");
            shop.DeliverProducts(bread, 30, 10);
            shop.DeliverProducts(cheese, 300, 10);
        }
    }
}
