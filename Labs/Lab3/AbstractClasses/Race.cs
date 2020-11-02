using System;
using System.Collections.Generic;

namespace Lab3.AbstractClasses
{
    public abstract class Race<T> where T : Vehicle
    {
        private double _distance;
        private List<T> _vehicles;

        protected Race(double distance)
        {
            _distance = distance;
            _vehicles = new List<T>();
        }

        public void AddVehile(T vehicle)
        {
            _vehicles.Add(vehicle);
        }

       public T RunRace()
        {
            T winner = default;
            double winnerTime = Double.MaxValue;
            foreach (var vehicle in _vehicles)
            {
                double time = vehicle.DistanceTime(_distance);
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