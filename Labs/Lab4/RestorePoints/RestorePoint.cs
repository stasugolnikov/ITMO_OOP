using System;
using System.Collections.Generic;

namespace Lab4.RestorePoints
{
    public abstract class RestorePoint
    {
        public DateTime CreationTime { get; }

        public long Size
        {
            get
            {
                long res = 0;
                foreach (var fileCopyInfo in FileCopyInfos)
                {
                    res += fileCopyInfo.Size;
                }

                return res;
            }
        }

        public List<FileCopyInfo> FileCopyInfos { get; }

        protected abstract FileCopyInfo CreateFileCopyInfo(string filePath);

        public RestorePoint(DateTime dateTime)
        {
            CreationTime = dateTime;
            FileCopyInfos = new List<FileCopyInfo>();
        }

        public void AddFileCopyInfo(FileCopyInfo fileCopyInfo)
        {
            FileCopyInfos.Add(fileCopyInfo);
        }

        public void SaveToFolder()
        {
            
        }

        public void SaveToArchive()
        {
            
        }
    }
}