using System;
using System.IO;

namespace Lab4.RestorePoints
{
    public class FullRestorePoint : RestorePoint
    {
        public FullRestorePoint(DateTime dateTime) : base(dateTime)
        {
        }

        protected override FileCopyInfo CreateFileCopyInfo(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return new FileCopyInfo(filePath, fileInfo.Length, DateTime.Now);
        }
    }
}