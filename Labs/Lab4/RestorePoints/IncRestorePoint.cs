using System;
using System.IO;

namespace Lab4.RestorePoints
{
    public class IncRestorePoint : RestorePoint
    {
        public IncRestorePoint(DateTime dateTime) : base(dateTime)
        {
        }

        protected override FileCopyInfo CreateFileCopyInfo(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return new FileCopyInfo(filePath, Convert.ToInt64(fileInfo.Length * 0.9), DateTime.Now);
        }
    }
}