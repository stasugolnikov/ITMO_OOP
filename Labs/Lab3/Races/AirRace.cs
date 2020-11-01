using System;
using System.Collections.Generic;
using Lab3.AbstractClasses;

namespace Lab3.Races
{
    public class AirRace : Race<AirVehicle>
    {
        public AirRace(double distance) : base(distance)
        {
        }
    }
}

