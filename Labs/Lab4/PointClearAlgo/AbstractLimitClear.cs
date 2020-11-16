using Lab4.RestorePoints;

namespace Lab4.PointClearAlgo
{
    public abstract class AbstractLimitClear
    {
        public abstract bool IsLimitExceeded(Backup backup);

        public static bool IsRemovable(Backup backup, RestorePoint restorePoint)
        {
            int pos = backup.RestorePoints.IndexOf(restorePoint);
            if (backup.RestorePoints.Count > 1 && backup.RestorePoints[pos + 1] is IncRestorePoint)
            {
                return false;
            }

            return true;
        }


        public void Clear(Backup backup)
        {
            for (int i = 0; i < backup.RestorePoints.Count; i++)
            {
                if (IsLimitExceeded(backup))
                {
                    if (IsRemovable(backup, backup.RestorePoints[i]))
                    {
                        backup.RemoveRestorePoint(backup.RestorePoints[i]);
                        i--;
                        continue;
                    }
                    throw new NotRemovablePointException("Try to remove not removable point");
                }
            }
        }
    }
}