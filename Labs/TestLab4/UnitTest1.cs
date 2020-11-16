using System;
using System.Collections.Generic;
using Lab4;
using Lab4.CreationAlgo;
using Lab4.PointClearAlgo;
using Lab4.RestorePoints;
using Lab4.StorageAlgo;
using NUnit.Framework;

namespace TestLab4
{
    public class Tests
    {
        [Test]
        public void TestCase1()
        {
            List<string> filesPath = new List<string>() {"/path/file1", "/path/file2"};
            Backup backup = new Backup(2345, filesPath, DateTime.Now);
            FolderStorageAlgo storage = new FolderStorageAlgo();
            var copies = storage.Save(backup.FilesPath);
            FullRestorePointCreation pointCreation = new FullRestorePointCreation();
            var point = pointCreation.Create(copies);
            backup.AddRestorePoint(point);
            Assert.AreEqual(200, backup.Size);
            AmountLimitClear cleaner = new AmountLimitClear(1);
            cleaner.Clear(backup);
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }

        [Test]
        public void TestCase2()
        {
            List<string> filesPath = new List<string>() {"/path/file1", "/path/file2", "/path/file3"};
            Backup backup = new Backup(2345, filesPath, DateTime.Now);
            FolderStorageAlgo storage = new FolderStorageAlgo();
            var copies1 = storage.Save(backup.FilesPath);
            FullRestorePointCreation pointCreation1 = new FullRestorePointCreation();
            var point1 = pointCreation1.Create(copies1);
            backup.AddRestorePoint(point1);

            var copies2 = storage.Save(backup.FilesPath);
            FullRestorePointCreation pointCreation2 = new FullRestorePointCreation();
            var point2 = pointCreation2.Create(copies2);
            backup.AddRestorePoint(point2);


            List<AbstractLimitClear> cleaners = new List<AbstractLimitClear>()
                {new AmountLimitClear(1), new SizeLimitClear(400)};

            HybridAllLimitClear cleaner = new HybridAllLimitClear(cleaners);
            cleaner.Clear(backup);
            Assert.AreEqual(300, backup.Size);
        }
    }
}