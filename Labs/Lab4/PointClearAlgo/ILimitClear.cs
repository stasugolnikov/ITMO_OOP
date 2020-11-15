namespace Lab4.PointClearAlgo
{
    public interface ILimitClear
    {
        void Clear(Backup backup);
        bool IsLimitExceeded(Backup backup);
    }
}