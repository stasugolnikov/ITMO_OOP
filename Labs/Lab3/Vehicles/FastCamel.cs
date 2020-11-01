using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class FastCamel : GroundVehicle
    {
        public override int Speed { get; } = 40;
        protected override double TimeBeforeRest { get; } = 10;

        protected override double RestDuration(int iteration)
        {
            return iteration switch
            {
                1 => 5,
                2 => 6.5,
                _ => 8
            };
        }
    }
}