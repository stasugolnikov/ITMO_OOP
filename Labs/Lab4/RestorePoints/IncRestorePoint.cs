using System;
using System.Collections.Generic;

namespace Lab4.RestorePoints
{
    public class IncRestorePoint : RestorePoint
    {
        public IncRestorePoint(List<FileCopyInfo> fileCopyInfos, DateTime dateTime) : base(fileCopyInfos, dateTime)
        {
        }
    }
}