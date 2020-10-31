namespace Lab3.Interfaces
{
    public interface IGroundVehicle : IVehicle
    {
        float TimeBeforeRest { get; } 
        double RestDuration(int iteration);
    }
}