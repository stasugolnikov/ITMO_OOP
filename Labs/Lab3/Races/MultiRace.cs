using System;
using System.Collections.Generic;
using Lab3.Interfaces;

namespace Lab3.Races
{
    public class MultiRace : IRace
    {
        public List<IVehicle> Vehicles { get; }
        public double Distance { get; }

        public MultiRace(double distance)
        {
            Distance = distance;
            Vehicles = new List<IVehicle>();
        }

        public void AddVehile(IVehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public IVehicle RunRace()
        {
            IVehicle winner = null;
            double winnerTime = Double.MaxValue;
            foreach (var vehicle in Vehicles)
            {
                double time = vehicle.DistanceTime(Distance);
                if (time <= winnerTime)
                {
                    winnerTime = time;
                    winner = vehicle;
                }
            }

            return winner;
        }
    }
}