using System;
using System.Collections.Generic;
using Lab4;
using Lab4.PointClearAlgo;
using Lab4.RestorePoints;
using NUnit.Framework;

namespace TestLab4
{
    public class Tests
    {
        [Test]
        public void TestAmount()
        {
            FileCopyInfo fileCopyInfo1 = new FileCopyInfo("path1", 100, DateTime.Now);
            FileCopyInfo fileCopyInfo2 = new FileCopyInfo("path2", 250, DateTime.Now);
            
            RestorePoint restorePoint1 = new FullRestorePoint(DateTime.Now);
            restorePoint1.AddFileCopyInfo(fileCopyInfo1);
            restorePoint1.AddFileCopyInfo(fileCopyInfo2);
            
            Backup backup = new Backup(123, DateTime.Now);
            backup.AddRestorePoint(restorePoint1);
            
            Assert.AreEqual(2, backup.RestorePoints[0].FileCopyInfos.Count);
            
            RestorePoint restorePoint2 = new FullRestorePoint(DateTime.Now);
            restorePoint2.AddFileCopyInfo(fileCopyInfo1);
            restorePoint2.AddFileCopyInfo(fileCopyInfo2);
            
            backup.AddRestorePoint(restorePoint2);
            AmountLimitClear amountLimitClear = new AmountLimitClear(1);
            amountLimitClear.Clear(backup);
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }
        
        [Test]
        public void TestSize()
        {
            FileCopyInfo fileCopyInfo1 = new FileCopyInfo("path1", 100, DateTime.Now);
            FileCopyInfo fileCopyInfo2 = new FileCopyInfo("path2", 100, DateTime.Now);
            
            RestorePoint restorePoint1 = new FullRestorePoint(DateTime.Now);
            restorePoint1.AddFileCopyInfo(fileCopyInfo1);
            restorePoint1.AddFileCopyInfo(fileCopyInfo2);
            
            Backup backup = new Backup(123, DateTime.Now);
            backup.AddRestorePoint(restorePoint1);
            Assert.AreEqual(200, backup.Size);
            
            RestorePoint restorePoint2 = new FullRestorePoint(DateTime.Now);
            restorePoint2.AddFileCopyInfo(fileCopyInfo1);
            restorePoint2.AddFileCopyInfo(fileCopyInfo2);
            backup.AddRestorePoint(restorePoint2);
            Assert.AreEqual(2, backup.RestorePoints.Count);
            Assert.AreEqual(400, backup.Size);
            SizeLimitClear sizeLimitClear = new SizeLimitClear(250);
            sizeLimitClear.Clear(backup);
            Assert.AreEqual(1, backup.RestorePoints.Count);

        }
        [Test]
        public void TestHybrid()
        {
            FileCopyInfo fileCopyInfo1 = new FileCopyInfo("path1", 100, DateTime.Now);
            FileCopyInfo fileCopyInfo2 = new FileCopyInfo("path2", 100, DateTime.Now);
            
            RestorePoint restorePoint1 = new FullRestorePoint(DateTime.Now);
            restorePoint1.AddFileCopyInfo(fileCopyInfo1);
            restorePoint1.AddFileCopyInfo(fileCopyInfo2);
            RestorePoint restorePoint2 = new FullRestorePoint(DateTime.Now);
            restorePoint2.AddFileCopyInfo(fileCopyInfo1);
            restorePoint2.AddFileCopyInfo(fileCopyInfo2);
            RestorePoint restorePoint3 = new FullRestorePoint(DateTime.Now);
            restorePoint3.AddFileCopyInfo(fileCopyInfo1);
            restorePoint3.AddFileCopyInfo(fileCopyInfo2);
            
            Backup backup = new Backup(123, DateTime.Now);
            backup.AddRestorePoint(restorePoint1);
            backup.AddRestorePoint(restorePoint2);
            backup.AddRestorePoint(restorePoint3);

            

            SizeLimitClear sizeLimitClear = new SizeLimitClear(250);
            AmountLimitClear amountLimitClear = new AmountLimitClear(2);

            List<AbstractLimitClear> algos = new List<AbstractLimitClear>() {amountLimitClear, sizeLimitClear};

            HybridLimitClear hybridLimitClear = new HybridLimitClear(algos);
            hybridLimitClear.AtLeastOneLimintsExceededClear(backup);
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }
        
    }
}