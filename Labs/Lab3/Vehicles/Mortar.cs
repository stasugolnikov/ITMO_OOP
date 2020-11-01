using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class Mortar : AirVehicle
    {
        public override int Speed { get; } = 10;

        protected override double DistanceReducer(double distance)
        {
            return distance * 0.96;
        }
    }
}