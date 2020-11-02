using System;
using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class Broom : AirVehicle
    {
        public override int Speed { get; } = 10;

        protected override double DistanceReducer(double distance)
        {
            int amount = Convert.ToInt32(distance / 1000);
            return distance * Math.Pow(0.9, amount);
        }
    }
}