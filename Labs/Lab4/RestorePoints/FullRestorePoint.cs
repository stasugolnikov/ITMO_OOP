using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4.RestorePoints
{
    public class FullRestorePoint : RestorePoint
    {
        public FullRestorePoint(List<FileCopyInfo> fileCopyInfos, DateTime dateTime) : base(fileCopyInfos, dateTime)
        {
        }

    }
}