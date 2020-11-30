using System;

namespace Lab5
{
    public class UnavaliableOperationException : Exception
    {
        public UnavaliableOperationException(string message) : base(message)
        {
        }
    }
    
    public class NonExistentIdException : Exception
    {
        public NonExistentIdException(string message) : base(message)
        {
        }
    }

}