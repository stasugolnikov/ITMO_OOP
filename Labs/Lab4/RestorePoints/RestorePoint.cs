using System;
using System.Collections.Generic;
using Lab4.Enums;

namespace Lab4.RestorePoints
{
    public abstract class RestorePoint
    {
        public DateTime CreationTime { get; }
        public long Size { get; private set; }
        public List<FileCopyInfo> FileCopyInfos { get; }

        protected abstract FileCopyInfo CreateFileCopyInfo(string filePath);

        public RestorePoint(DateTime dateTime)
        {
            CreationTime = dateTime;
            Size = 0;
            FileCopyInfos = new List<FileCopyInfo>();
        }

        public void AddFileCopyInfo(FileCopyInfo fileCopyInfo)
        {
            Size += fileCopyInfo.Size;
            FileCopyInfos.Add(fileCopyInfo);
        }

        public void RemoveFileCopyInfo(FileCopyInfo fileCopyInfo)
        {
            Size -= fileCopyInfo.Size;
            int pos = FileCopyInfos.FindIndex(info => info.FilePath == fileCopyInfo.FilePath);
            FileCopyInfos.RemoveAt(pos);
        }
    }
}