namespace Lab4.PointClearAlgo
{
    public class SizeLimitClear : AbstractLimitClear
    {
        private long _limitValue;
        public SizeLimitClear(long size)
        {
            _limitValue = size;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitValue < backup.Size;
        }
    }
}