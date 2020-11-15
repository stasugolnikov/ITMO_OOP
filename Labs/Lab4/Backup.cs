using System;
using System.Collections.Generic;
using Lab4.RestorePoints;

namespace Lab4
{
    public class Backup
    {
        public int Id { get; }
        public DateTime CreationTime { get; }
        public long Size { get; private set; }

        public List<RestorePoint> RestorePoints { get; }

        public Backup(int id, DateTime dateTime)
        {
            Id = id;
            CreationTime = dateTime;
            Size = 0;
            RestorePoints = new List<RestorePoint>();
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            Size += restorePoint.Size;
            RestorePoints.Add(restorePoint);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            int pos = RestorePoints.IndexOf(restorePoint);
            if (RestorePoints.Count != 1 && RestorePoints[pos + 1] is IncRestorePoint)
            {
                //Предупреждение
                return;
            }

            Size -= restorePoint.Size;
            RestorePoints.RemoveAt(pos);
        }
    }
}