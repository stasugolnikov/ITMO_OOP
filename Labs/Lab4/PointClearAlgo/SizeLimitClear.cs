namespace Lab4.PointClearAlgo
{
    public class SizeLimitClear : AbstractLimitClear<long>
    {
        public SizeLimitClear(long size) : base(size)
        {
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return LimitValue > backup.Size;
        }
    }
}