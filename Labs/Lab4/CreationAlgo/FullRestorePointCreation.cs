using System;
using System.Collections.Generic;
using Lab4.RestorePoints;

namespace Lab4.CreationAlgo
{
    public class FullRestorePointCreation : AbstractPointCreation
    {
        public override RestorePoint Create(List<FileCopyInfo> fileCopyInfos)
        {
            return new FullRestorePoint(fileCopyInfos, DateTime.Now);
        }
    }
}