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

        protected abstract FileCopyInfo CreateFileCopyInfo(string fileName, long size);

        public RestorePoint(DateTime dateTime)
        {
            CreationTime = dateTime;
            FileCopyInfos = new List<FileCopyInfo>();
        }

        public void AddFileCopyInfo(FileCopyInfo fileCopyInfo)
        {
            FileCopyInfos.Add(fileCopyInfo);
        }

        public void SaveToFolder(List<string> filesPath)
        {
            foreach (var filePath in filesPath)
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                FileCopyInfos.Add(CreateFileCopyInfo("Directory\\" + fileName, 100));
            }
        }

        public void SaveToArchive(List<string> filesPath)
        {
            long archiveSize = 0;
            foreach (var filePath in filesPath)
            {
                archiveSize += CreateFileCopyInfo(filePath, 100).Size;
            }
            FileCopyInfos.Add(CreateFileCopyInfo("Archive", archiveSize));
        }
    }
}