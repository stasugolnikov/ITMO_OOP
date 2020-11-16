using System;
using System.Collections.Generic;
using Lab4.RestorePoints;

namespace Lab4.CreationAlgo
{
    public class IncRestorePointCreation : AbstractPointCreation
    {
        public override RestorePoint Create(List<FileCopyInfo> fileCopyInfos)
        {
            return new IncRestorePoint(fileCopyInfos, DateTime.Now);
        }
    }
}