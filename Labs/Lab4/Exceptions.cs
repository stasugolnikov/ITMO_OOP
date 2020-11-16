using System;

namespace Lab4
{
    public class NotRemovablePointException : Exception
    {
        public NotRemovablePointException(string message) : base(message)
        {
        }
    }
    public class UnavaliableIncPointCreation : Exception
    {
        public UnavaliableIncPointCreation(string message) : base(message)
        {
        }
    }
}