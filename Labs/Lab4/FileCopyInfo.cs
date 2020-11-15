using System;

namespace Lab4
{
    public class FileCopyInfo
    {
        public string FilePath { get; }
        public long Size { get; }
        public DateTime CreationTime { get; }

        public FileCopyInfo(string filePath, long size, DateTime creationTime)
        {
            FilePath = filePath;
            Size = size;
            CreationTime = creationTime;
        }
    }
}