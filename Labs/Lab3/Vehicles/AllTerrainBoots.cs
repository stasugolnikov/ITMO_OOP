using System;
using Lab3.Interfaces;

namespace Lab3.Vehicles
{
    public class AllTerrainBoots : IGroundVehicle
    {

        public int Speed { get; } = 6;
        public float TimeBeforeRest { get; } = 60;

        public double RestDuration(int iteration)
        {
            return iteration == 1 ? 10 : 5;
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