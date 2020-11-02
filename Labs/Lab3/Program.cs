using System;
using Lab3.AbstractClasses;
using Lab3.Races;
using Lab3.Vehicles;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            AllTerrainBoots atb = new AllTerrainBoots();
            FastCamel fc = new FastCamel();
            TwoHumpedCamel thc = new TwoHumpedCamel();
            Broom b = new Broom();
            FlyingCarpert fl = new FlyingCarpert();
            MultiRace multiRace = new MultiRace(1000);
            multiRace.AddVehile(atb);
            multiRace.AddVehile(fc);
            multiRace.AddVehile(thc);
            multiRace.AddVehile(b);
            multiRace.AddVehile(fl);
            Vehicle v = multiRace.RunRace();
            Console.WriteLine(v.Speed);
        }
    }
}