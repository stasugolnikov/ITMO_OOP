using System;

namespace Lab1
{
    public class InvalidSectionException : Exception
    {
        public InvalidSectionException(string message) : base(message)
        {
        }
    }

    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string message) : base(message)
        {
        }
    }

    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message) : base(message)
        {
        }
    }

    public class InvalidLineException : Exception
    {
        public InvalidLineException(string message) : base(message)
        {
        }
    }

    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException(string message) : base(message)
        {
        }
    }
}