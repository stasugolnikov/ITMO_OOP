namespace Lab4.PointClearAlgo
{
    public class SizeLimitClear : AbstractLimitClear
    {
        private long _limitvalue;
        public SizeLimitClear(long size)
        {
            _limitvalue = size;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitvalue > backup.Size;
        }
    }
}