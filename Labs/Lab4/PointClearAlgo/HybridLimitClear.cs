using System.Collections.Generic;

namespace Lab4.PointClearAlgo
{
    public class HybridLimitClear
    {
        public List<AmountLimitClear> PointClearAlgorithms { get; }

        public HybridLimitClear(List<AmountLimitClear> pointClearAlgorithms)
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
                        if (AbstractLimitClear.IsRemovable(backup, restorePoint))
                        {
                            backup.RemoveRestorePoint(restorePoint);
                            break;
                        }
                        throw new NotRemovablePointException("Try to remove not removable point");
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

                if (to_delete && AbstractLimitClear.IsRemovable(backup, restorePoint))
                {
                    backup.RemoveRestorePoint(restorePoint);
                    continue;
                }
                throw new NotRemovablePointException("Try to remove not removable point");
            }
        }
    }
}