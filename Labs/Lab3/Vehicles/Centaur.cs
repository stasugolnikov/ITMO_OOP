using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class Centaur : GroundVehicle
    {
        public override int Speed { get; } = 15;
        protected override double TimeBeforeRest { get; } = 8;

        protected override double RestDuration(int iteration)
        {
            return 2;
        }
    }
}