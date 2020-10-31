using System;
using Lab3.Interfaces;

namespace Lab3.Vehicles
{
    public class TwoHumpedCamel : IGroundVehicle
    {
        public int Speed { get; } = 10;
        public float TimeBeforeRest { get; } = 30;

        public double RestDuration(int iteration)
        {
            return iteration == 1 ? 5 : 8;
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