using System;
using System.Collections.Generic;
using Lab3.AbstractClasses;

namespace Lab3.Races
{
    public class GroundRace : Race<GroundVehicle>
    {
        public GroundRace(double distance) : base(distance)
        {
        }
    }
}