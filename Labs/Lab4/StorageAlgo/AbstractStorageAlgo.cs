using System;
using System.Collections.Generic;

namespace Lab4.StorageAlgo
{
    public abstract class AbstractStorageAlgo
    {
        protected abstract FileCopyInfo CreateFileCopyInfo(string filePath, long size);

        public abstract List<FileCopyInfo> Save(List<string> filesPath);
    }
}