using System;

namespace Lab3
{
    public class VehicleTypeException : Exception
    {
        public VehicleTypeException(string message) : base(message)
        {
        }
    }
}