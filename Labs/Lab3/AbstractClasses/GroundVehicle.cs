using System;

namespace Lab3.AbstractClasses
{
    public abstract class GroundVehicle : Vehicle
    {
        protected abstract double TimeBeforeRest { get; }
        protected abstract double RestDuration(int iteration);

        public override double DistanceTime(double distance)
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