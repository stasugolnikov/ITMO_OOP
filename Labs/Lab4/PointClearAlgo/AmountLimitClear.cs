namespace Lab4.PointClearAlgo
{
    public class AmountLimitClear : AbstractLimitClear<int>
    {
        public AmountLimitClear(int amount) : base(amount)
        {
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return LimitValue > backup.RestorePoints.Count;
        }
    }
}