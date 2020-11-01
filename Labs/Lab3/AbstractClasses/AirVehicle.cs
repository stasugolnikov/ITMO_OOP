namespace Lab3.AbstractClasses
{
    public abstract class AirVehicle : Vehicle
    {
        protected abstract double DistanceReducer(double distance);

        public override double DistanceTime(double distance)
        {
            return DistanceReducer(distance) / Speed;
        }
    }
}