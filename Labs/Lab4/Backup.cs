using System;
using System.Collections.Generic;
using Lab4.RestorePoints;

namespace Lab4
{
    public class Backup
    {
        public int Id { get; }
        public DateTime CreationTime { get; }

        public long Size
        {
            get
            {
                long res = 0;
                foreach (var restorePoint in RestorePoints)
                {
                    res += restorePoint.Size;
                }

                return res;
            }
        }

        public List<RestorePoint> RestorePoints { get; }

        public Backup(int id, DateTime dateTime)
        {
            Id = id;
            CreationTime = dateTime;
            RestorePoints = new List<RestorePoint>();
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            RestorePoints.Add(restorePoint);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {

            RestorePoints.Remove(restorePoint);
        }
    }
}