using System;

namespace Lab1
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message) : base(message)
        {
        }
    }

    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException(string message) : base(message)
        {
        }
    }

    public class UnknownPairException : Exception
    {
        public UnknownPairException(string message) : base(message)
        {
        }
    }
    public class FormatingException : Exception
    {
        public FormatingException(string message) : base(message)
        {
        }
    }
}