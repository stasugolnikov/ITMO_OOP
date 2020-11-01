using System;
using Lab3.AbstractClasses;

namespace Lab3.Vehicles
{
    public class AllTerrainBoots : GroundVehicle
    {
        public override int Speed { get; } = 6;
        protected override double TimeBeforeRest { get; } = 60;

        protected override double RestDuration(int iteration)
        {
            return iteration == 1 ? 10 : 5;
        }
    }
}