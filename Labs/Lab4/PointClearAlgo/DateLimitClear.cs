using System;

namespace Lab4.PointClearAlgo
{
    public class DateLimitClear : AbstractLimitClear<DateTime>
    {
        public DateLimitClear(DateTime dateTime) : base(dateTime)
        {
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return LimitValue > backup.RestorePoints[0].CreationTime;
        }
    }
}