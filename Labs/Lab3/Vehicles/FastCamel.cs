using System;
using Lab3.Interfaces;

namespace Lab3.Vehicles
{
    public class FastCamel : IGroundVehicle
    {
        public int Speed { get; } = 40;
        public float TimeBeforeRest { get; } = 10;

        public double RestDuration(int iteration)
        {
            return iteration switch
            {
                1 => 5,
                2 => 6.5,
                _ => 8
            };
        }

        public double DistanceTime(double distance)
        {
            double time = distance / Speed;
            int restAmount = Convert.ToInt32(time / TimeBeforeRest);
            double restTime = 0;
            for (int i = 0; i < restAmount; i++)
            {
                restTime += RestDuration(i);
            }

            return time + restTime;
        }
    }
}