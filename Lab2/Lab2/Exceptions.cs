using System;

namespace Lab2
{
    public class ExistingProductIDException : Exception
    {
        public ExistingProductIDException(string message) : base(message)
        {
        }
    }
    public class NotExistingProductIDException : Exception
    {
        public NotExistingProductIDException(string message) : base(message)
        {
        }
    }
    public class ExistingShopIDException : Exception
    {
        public ExistingShopIDException(string message) : base(message)
        {
        }
    }
}