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
        public List<string> FilesPath { get; }

        public Backup(int id, List<string> filesPath, DateTime dateTime)
        {
            Id = id;
            CreationTime = dateTime;
            RestorePoints = new List<RestorePoint>();
            FilesPath = filesPath;
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            RestorePoints.Add(restorePoint);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            RestorePoints.Remove(restorePoint);
        }

        public void AddFilePath(string filePath)
        {
            FilesPath.Add(filePath);
        }

        public void RemoveFilePath(string filePath)
        {
            FilesPath.Remove(filePath);
        }

        public FullRestorePoint CreateFullRestorePoint()
        {
           var restorePoint = new FullRestorePoint(DateTime.Now);
           RestorePoints.Add(restorePoint);
           return restorePoint;
        }
        
        public IncRestorePoint CreateIncRestorePoint()
        {
            var restorePoint = new IncRestorePoint(DateTime.Now);
            RestorePoints.Add(restorePoint);
            return restorePoint;
        }

        public void SaveRestorePointToFolder(RestorePoint restorePoint)
        {
            restorePoint.SaveToFolder(FilesPath);
        }
        public void SaveRestorePointToArchive(RestorePoint restorePoint)
        {
            restorePoint.SaveToArchive(FilesPath);
        }
    }
}