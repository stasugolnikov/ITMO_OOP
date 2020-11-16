using System.Collections.Generic;
using Lab4.CreationAlgo;
using Lab4.PointClearAlgo;
using Lab4.StorageAlgo;

namespace Lab4
{
    public class BackupManager
    {
        public void Manage(Backup backup, AbstractLimitClear cleaner,
            AbstractStorageAlgo storage, AbstractPointCreation pointCreation)
        {
            var filesCopyInfo = storage.Save(backup.FilesPath);
            if (pointCreation is IncRestorePointCreation && backup.RestorePoints.Count == 0)
            {
                throw new UnavaliableIncPointCreation("No parent point");
            } 
            var restorePoint = pointCreation.Create(filesCopyInfo);
            backup.AddRestorePoint(restorePoint);
            cleaner.Clear(backup);
        }
    }
}