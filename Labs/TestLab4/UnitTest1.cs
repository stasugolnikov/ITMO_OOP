using System;
using Lab4;
using Lab4.PointClearAlgo;
using Lab4.RestorePoints;
using NUnit.Framework;

namespace TestLab4
{
    public class Tests
    {
        [Test]
        public void TestCase1()
        {
            FileCopyInfo fileCopyInfo1 = new FileCopyInfo("path1", 100, DateTime.Now);
            FileCopyInfo fileCopyInfo2 = new FileCopyInfo("path2", 250, DateTime.Now);
            
            RestorePoint restorePoint1 = new FullRestorePoint(DateTime.Now);
            restorePoint1.AddFileCopyInfo(fileCopyInfo1);
            restorePoint1.AddFileCopyInfo(fileCopyInfo2);
            
            Backup backup = new Backup(123, DateTime.Now);
            backup.AddRestorePoint(restorePoint1);
            
            Assert.AreEqual(2, backup.RestorePoints[0].FileCopyInfos.Count);
            AmountLimitClear amountLimitClear = new AmountLimitClear(1);
            amountLimitClear.Clear(backup);
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }
        
        [Test]
        public void TestCase2()
        {
            FileCopyInfo fileCopyInfo1 = new FileCopyInfo("path1", 100, DateTime.Now);
            FileCopyInfo fileCopyInfo2 = new FileCopyInfo("path2", 100, DateTime.Now);
            
            RestorePoint restorePoint1 = new FullRestorePoint(DateTime.Now);
            restorePoint1.AddFileCopyInfo(fileCopyInfo1);
            restorePoint1.AddFileCopyInfo(fileCopyInfo2);
            
            Backup backup = new Backup(123, DateTime.Now);
            backup.AddRestorePoint(restorePoint1);
            Assert.AreEqual(200, backup.Size);
            
            RestorePoint restorePoint2 = new IncRestorePoint(DateTime.Now);
            restorePoint2.AddFileCopyInfo(fileCopyInfo1);
            restorePoint2.AddFileCopyInfo(fileCopyInfo2);
            backup.AddRestorePoint(restorePoint2);
            Assert.AreEqual(2, backup.RestorePoints.Count);
            Assert.AreEqual(400, backup.Size);
        }
    }
}