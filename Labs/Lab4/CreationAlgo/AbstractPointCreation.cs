using System.Collections.Generic;
using Lab4.RestorePoints;

namespace Lab4.CreationAlgo
{
    public abstract class AbstractPointCreation
    {
        public abstract RestorePoint Create(List<FileCopyInfo> fileCopyInfos);
    }
}