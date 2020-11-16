namespace Lab4.PointClearAlgo
{
    public class AmountLimitClear : AbstractLimitClear
    {
        private int _limitValue;
        public AmountLimitClear(int amount)
        {
            _limitValue = amount;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitValue > backup.RestorePoints.Count;
        }
    }
}