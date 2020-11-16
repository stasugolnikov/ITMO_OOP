using System.Collections.Generic;

namespace Lab4.PointClearAlgo
{
    public class HybridAllLimitClear : AbstractLimitClear
    {
        public List<AbstractLimitClear> PointClearAlgorithms { get; }

        public HybridAllLimitClear(List<AbstractLimitClear> pointClearAlgorithms)
        {
            PointClearAlgorithms = pointClearAlgorithms;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            foreach (var algorithm in PointClearAlgorithms)
            {
                if (!algorithm.IsLimitExceeded(backup)) return false;
            }

            return true;
        }
    }
}