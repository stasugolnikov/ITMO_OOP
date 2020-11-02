using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class FlyingCarpert : AirVehicle
    {
        public override int Speed { get; } = 10;

        protected override double DistanceReducer(double distance)
        {
            if (distance <= 1000)
            {
                return distance;
            }

            if (distance <= 5000)
            {
                return distance * 0.97;
            }

            if (distance <= 10000)
            {
                return distance * 0.9;
            }

            return distance * 0.95;
        }
        
    }
}