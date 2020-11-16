using System;
using System.Collections.Generic;

namespace Lab4.StorageAlgo
{
    public class FolderStorageAlgo : AbstractStorageAlgo
    {
        protected override FileCopyInfo CreateFileCopyInfo(string filePath, long size)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            return new FileCopyInfo("Directory\\" + fileName, 100, DateTime.Now);
        }

        public override List<FileCopyInfo> Save(List<string> filesPath)
        {
            List<FileCopyInfo> res = new List<FileCopyInfo>();
            foreach (var filePath in filesPath)
            {
                res.Add(CreateFileCopyInfo(filePath, 100));
            }

            return res;
        }
    }
}