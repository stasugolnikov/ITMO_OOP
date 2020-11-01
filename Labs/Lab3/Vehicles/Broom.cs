using System;
using Lab3.Interfaces;

namespace Lab3.Vehicles
{
    public class Broom : IAirVehicle
    {
        public int Speed { get; } = 10;

        public double DistanceReducer(double distance)
        {
            int amount = Convert.ToInt32(distance / 1000);
            return distance * Math.Pow(0.9, amount);
        }

        public double DistanceTime(double distance)
        {
            return DistanceReducer(distance) / Speed;
        }
    }
}