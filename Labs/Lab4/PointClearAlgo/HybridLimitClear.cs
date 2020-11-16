using System.Collections.Generic;

namespace Lab4.PointClearAlgo
{
    public class HybridLimitClear
    {
        public List<AbstractLimitClear> PointClearAlgorithms { get; }

        public HybridLimitClear(List<AbstractLimitClear> pointClearAlgorithms)
        {
            PointClearAlgorithms = pointClearAlgorithms;
        }

        public void AtLeastOneLimintsExceededClear(Backup backup)
        {
            for (int i = 0; i < backup.RestorePoints.Count; i++)
            {
                foreach (var algorithm in PointClearAlgorithms)
                {
                    if (algorithm.IsLimitExceeded(backup))
                    {
                        if (AbstractLimitClear.IsRemovable(backup, backup.RestorePoints[i]))
                        {
                            backup.RemoveRestorePoint(backup.RestorePoints[i]);
                            i--;
                            break;
                        }
                        throw new NotRemovablePointException("Try to remove not removable point");
                    }
                }
            }
        }

        public void AllLimintsExceededClear(Backup backup)
        {
            for (int i = 0; i < backup.RestorePoints.Count; i++)
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

                if (to_delete && AbstractLimitClear.IsRemovable(backup, backup.RestorePoints[i]))
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