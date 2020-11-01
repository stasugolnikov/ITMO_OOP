using Lab3.Interfaces;

namespace Lab3.Vehicles
{
    public class FlyingCarpert : IAirVehicle
    {
        public int Speed { get; } = 10;

        public double DistanceReducer(double distance)
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

        public double DistanceTime(double distance)
        {
            return DistanceReducer(distance) / Speed;
        }
    }
}