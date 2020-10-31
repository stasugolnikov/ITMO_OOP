namespace Lab3.Interfaces
{
    public interface IVehicle
    {
        int Speed { get; }
        double DistanceTime(double distance);
    }
}