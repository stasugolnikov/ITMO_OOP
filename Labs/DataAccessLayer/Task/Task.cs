using System;
using System.Collections.Generic;
using DataAccessLayer.Abstractions;

namespace DataAccessLayer.Task
{
    public class Task
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Comment { get; set; }
        public Worker.Worker Worker { get; set; }
        public TaskState State { get; set; }
        public DateTime LastChangesDate { get; }
        public List<(Worker.Worker worker, AbstractSetter setter)> Log { get; }
        
        private static int _idCounter;

        public Task(string name, string description, Worker.Worker worker)
        {
            Id = _idCounter++;
            Name = name;
            Description = description;
            Worker = worker;
            State = TaskState.Open;
            LastChangesDate = DateTime.Now;
            Log = new List<(Worker.Worker worker, AbstractSetter setter)>();
        }
    }
}