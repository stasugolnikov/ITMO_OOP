using System;
using System.Collections.Generic;
using DataAccessLayer.Reports;

namespace DataAccessLayer.Abstractions
{
    public abstract class AbstractReport
    {
        public int Id { get; }
        public List<Task.Task> Tasks { get; }
        public ReportState State { get; set; }
        public DateTime CreationDate { get; }

        private static int _idCounter;

        public AbstractReport()
        {
            Id = _idCounter++;
            Tasks = new List<Task.Task>();
            State = ReportState.Open;
            CreationDate = DateTime.Now;
        }

        public void AddTask(Task.Task task) => Tasks.Add(task);
    }
}