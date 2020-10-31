using Lab3.Interfaces;


namespace Lab3.Vehicles
{
    public class Mortar : IAirVehicle
    {
        public int Speed { get; } = 10;

        public double DistanceReducer(double distance)
        {
            return distance * 0.96;
        }

        public double DistanceTime(double distance)
        {
            return DistanceReducer(distance) / Speed;
        }
    }
}