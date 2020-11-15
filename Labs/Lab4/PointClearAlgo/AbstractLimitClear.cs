namespace Lab4.PointClearAlgo
{
    public abstract class AbstractLimitClear<T> : ILimitClear
    {
        protected T LimitValue { get; }

        protected AbstractLimitClear(T limitValue)
        {
            LimitValue = limitValue;
        }


        public abstract bool IsLimitExceeded(Backup backup);

        public void Clear(Backup backup)
        {
            foreach (var restorePoint in backup.RestorePoints)
            {
                if (!IsLimitExceeded(backup))
                {
                    break;
                }

                backup.RemoveRestorePoint(restorePoint);
            }
        }
    }
}