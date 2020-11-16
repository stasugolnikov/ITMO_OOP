using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> filesPath = new List<string>() {"\\aaa\\bbb", "\\ccc\\ddd"};
            Backup backup = new Backup(12345, filesPath, DateTime.Now);
            backup.AddFilePath("\\eee\\fff");
            backup.SaveRestorePointToArchive(backup.CreateFullRestorePoint());
        }
    }
}