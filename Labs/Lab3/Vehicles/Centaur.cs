using System;
using Lab3.Interfaces;

namespace Lab3.Vehicles
{
    public class Centaur : IGroundVehicle
    {
        public int Speed { get; } = 15;
        public float TimeBeforeRest { get; } = 8;

        public double RestDuration(int iteration = 0)
        {
            return 2;
        }

        public double DistanceTime(double distance)
        {
            double time = distance / Speed;
            int restAmount = Convert.ToInt32(time / TimeBeforeRest);
            double restTime = 0;
            for (int i = 0; i < restAmount; i++)
            {
                restTime += RestDuration();
            }

            return time + restTime;
        }
    }
}