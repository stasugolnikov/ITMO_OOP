using System;
using System.IO;

namespace Lab4.RestorePoints
{
    public class FullRestorePoint : RestorePoint
    {
        public FullRestorePoint(DateTime dateTime) : base(dateTime)
        {
        }

        protected override FileCopyInfo CreateFileCopyInfo(string filePath, long size)
        {
            return new FileCopyInfo(filePath, size, DateTime.Now);
        }
    }
}