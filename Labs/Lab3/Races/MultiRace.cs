using System;
using System.Collections.Generic;
using Lab3.AbstractClasses;

namespace Lab3.Races
{
    public class MultiRace : Race<Vehicle>
    {
        public MultiRace(double distance) : base(distance)
        {
        }
    }
}