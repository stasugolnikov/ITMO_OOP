using System;
using System.IO;

namespace Lab4.RestorePoints
{
    public class IncRestorePoint : RestorePoint
    {
        public IncRestorePoint(DateTime dateTime) : base(dateTime)
        {
        }

        protected override FileCopyInfo CreateFileCopyInfo(string filePath, long size)
        {
            return new FileCopyInfo(filePath, size, DateTime.Now);
        }
    }
}