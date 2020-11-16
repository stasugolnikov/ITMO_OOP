using System;
using System.Collections.Generic;

namespace Lab4.RestorePoints
{
    public abstract class RestorePoint
    {
        public DateTime CreationTime { get; }
        public List<FileCopyInfo> FileCopyInfos { get; }
        
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

        public RestorePoint(List<FileCopyInfo> fileCopyInfos, DateTime dateTime)
        {
            CreationTime = dateTime;
            FileCopyInfos = fileCopyInfos;
        }

        public void AddFileCopyInfo(FileCopyInfo fileCopyInfo)
        {
            FileCopyInfos.Add(fileCopyInfo);
        }
    }
}