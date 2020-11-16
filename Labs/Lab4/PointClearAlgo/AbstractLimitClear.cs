using Lab4.RestorePoints;

namespace Lab4.PointClearAlgo
{
    public abstract class AbstractLimitClear
    {
        public abstract bool IsLimitExceeded(Backup backup);

        public static bool IsRemovable(Backup backup, RestorePoint restorePoint)
        {
            int pos = backup.RestorePoints.IndexOf(restorePoint);
            if (backup.RestorePoints.Count != 1 && backup.RestorePoints[pos + 1] is IncRestorePoint)
            {
                return false;
            }

            return true;
        }


        public void Clear(Backup backup)
        {
            foreach (var restorePoint in backup.RestorePoints)
            {
                if (!IsLimitExceeded(backup))
                {
                    break;
                }

                if (!IsRemovable(backup, restorePoint))
                {
                    throw new NotRemovablePointException("Try to remove not removable point");
                }
                backup.RemoveRestorePoint(restorePoint);
            }
        }
    }
}