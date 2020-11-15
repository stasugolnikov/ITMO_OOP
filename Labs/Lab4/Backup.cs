using System;
using System.Collections.Generic;
using Lab4.Enums;
using Lab4.RestorePoints;

namespace Lab4
{
    public class Backup
    {
        public int Id { get; }
        public DateTime CreationTime { get; }
        public long Size { get; private set; }

        public List<RestorePoint> RestorePoints { get; }
        public List<string> FilesPath { get; }

        public Backup(int id, DateTime dateTime, List<string> filesPath)
        {
            Id = id;
            CreationTime = dateTime;
            Size = 0;
            FilesPath = filesPath;
            RestorePoints = new List<RestorePoint>();
        }

        private void DiscreteStorage(RestorePoint restorePoint)
        {
        }

        private void FullStorage(RestorePoint restorePoint)
        {
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            Size += restorePoint.Size;
            RestorePoints.Add(restorePoint);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            Size -= restorePoint.Size;
            int pos = RestorePoints.IndexOf(restorePoint);
            RestorePoints.RemoveAt(pos);
        }

        public void CreateRestorePoint(RestorePointType restorePointType, StorageType storageType, DateTime dateTime)
        {
            RestorePoint restorePoint = null;
            switch (restorePointType)
            {
                case RestorePointType.Increment:
                    restorePoint = new IncRestorePoint(dateTime);
                    AddRestorePoint(restorePoint);
                    break;
                case RestorePointType.Full:
                    restorePoint = new FullRestorePoint(dateTime);
                    AddRestorePoint(restorePoint);
                    break;
            }

            switch (storageType)
            {
                case StorageType.Discrete:
                    DiscreteStorage(restorePoint);
                    break;
                case StorageType.Full:
                    FullStorage(restorePoint);
                    break;
            }
        }

        public int AmountLimitClear(int amount)
        {
            int ans = 0;
            for (int i = 0; i < RestorePoints.Count - 1; i++)
            {
                if (RestorePoints.Count <= amount) break;
                if (RestorePoints[i + 1] is IncRestorePoint)
                {
                    // Предупреждение
                    break;
                }

                //RestorePoints.RemoveAt(0);
                ans++;
            }

            return RestorePoints.Count - ans;
        }

        public int DateLimitClear(DateTime dateTime)
        {
            int ans = 0;
            foreach (var restorePoint in RestorePoints)
            {
                if (restorePoint.CreationTime <= dateTime) break;
                //RemoveRestorePoint(restorePoint);
                ans++;
            }

            return RestorePoints.Count - ans;
        }

        public int SizeLimitClear(long size)
        {
            int ans = 0;
            foreach (var restorePoint in RestorePoints)
            {
                if (size >= Size) break;
                //RemoveRestorePoint(restorePoint);
                ans++;
            }

            return RestorePoints.Count - ans;
        }


        private int GetLimitValue(KeyValuePair<LimitType, object> limit)
        {
            switch (limit.Key)
            {
                case LimitType.AmoutLimit:
                    return AmountLimitClear((int) limit.Value);
                case LimitType.DateLimit:
                    return DateLimitClear((DateTime) limit.Value);
                case LimitType.SizeLimit:
                    return SizeLimitClear((long) limit.Value);
            }

            return -1;
        }

        public int HybridClear(PointsAmount pointsAmount, params KeyValuePair<LimitType, object>[] limits)
        {
            if (pointsAmount == PointsAmount.Max)
            {
                int max = Int32.MinValue;
                foreach (var limit in limits)
                {
                    max = Math.Max(max, GetLimitValue(limit));
                }

                return max;
            }
            int min = Int32.MaxValue;
            foreach (var limit in limits)
            {
                min = Math.Max(min, GetLimitValue(limit));
            }

            return min;
        }
    }
}