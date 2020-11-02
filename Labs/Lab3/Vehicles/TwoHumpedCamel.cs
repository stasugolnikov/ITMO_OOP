using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class TwoHumpedCamel : GroundVehicle
    {
        public override int Speed { get; } = 10;
        protected override double TimeBeforeRest { get; } = 30;

        protected override double RestDuration(int iteration)
        {
            return iteration == 1 ? 5 : 8;
        }
    }
}