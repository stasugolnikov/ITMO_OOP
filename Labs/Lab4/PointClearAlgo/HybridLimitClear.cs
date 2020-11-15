using System.Collections.Generic;

namespace Lab4.PointClearAlgo
{
    public class HybridLimitClear
    {
        public List<ILimitClear> PointClearAlgorithms { get; }

        public HybridLimitClear(List<ILimitClear> pointClearAlgorithms)
        {
            PointClearAlgorithms = pointClearAlgorithms;
        }

        public void AtLeastOneLimintsExceededClear(Backup backup)
        {
            foreach (var restorePoint in backup.RestorePoints)
            {
                foreach (var algorithm in PointClearAlgorithms)
                {
                    if (algorithm.IsLimitExceeded(backup))
                    {
                        backup.RemoveRestorePoint(restorePoint);
                        break;
                    }
                }
            }
        }

        public void AllLimintsExceededClear(Backup backup)
        {
            foreach (var restorePoint in backup.RestorePoints)
            {
                bool to_delete = true;
                foreach (var algorithm in PointClearAlgorithms)
                {
                    if (!algorithm.IsLimitExceeded(backup))
                    {
                        to_delete = false;
                        break;
                    }
                }

                if (to_delete)
                {
                    backup.RemoveRestorePoint(restorePoint);
                }
            }
        }
    }
}