using System;

namespace Lab4.PointClearAlgo
{
    public class DateLimitClear : AbstractLimitClear
    {
        private DateTime _limitValue;
        public DateLimitClear(DateTime dateTime)
        {
            _limitValue = dateTime;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitValue < backup.RestorePoints[0].CreationTime;
        }
    }
}