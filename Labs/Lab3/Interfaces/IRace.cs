using System.Collections.Generic;

namespace Lab3.Interfaces
{
    public interface IRace
    {
        double Distance { get; }
        List<IVehicle> Vehicles { get; }
        void AddVehile(IVehicle vehicle);
        IVehicle RunRace();
    }
}