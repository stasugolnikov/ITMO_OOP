using System;
using System.Collections.Generic;

namespace Lab4.StorageAlgo
{
    public class ArchiveStorageAlgo : AbstractStorageAlgo
    {
        protected override FileCopyInfo CreateFileCopyInfo(string filePath, long size)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            return new FileCopyInfo("Archive." + fileName, 100, DateTime.Now);
        }

        public override List<FileCopyInfo> Save(List<string> filesPath)
        {
            long archiveSize = 0;
            foreach (var filePath in filesPath)
            {
                archiveSize += CreateFileCopyInfo(filePath, 100).Size;
            }

            return new List<FileCopyInfo>() {CreateFileCopyInfo("Archive", archiveSize)};
        }
    }
}