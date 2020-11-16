using System.Collections.Generic;

namespace Lab4.PointClearAlgo
{
    public class HybridAtLeastOneLimitClear : AbstractLimitClear
    {
        public List<AbstractLimitClear> PointClearAlgorithms { get; }

        public HybridAtLeastOneLimitClear(List<AbstractLimitClear> pointClearAlgorithms)
        {
            PointClearAlgorithms = pointClearAlgorithms;
        }


        public override bool IsLimitExceeded(Backup backup)
        {
            foreach (var algorithm in PointClearAlgorithms)
            {
                if (algorithm.IsLimitExceeded(backup)) return true;
            }

            return false;
        }
    }
}