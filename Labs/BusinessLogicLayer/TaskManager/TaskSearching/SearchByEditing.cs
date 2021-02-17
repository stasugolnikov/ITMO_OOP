using System;
using System.Collections.Generic;
using DataAccessLayer.Abstractions;
using DataAccessLayer.Task;
using DataAccessLayer.Worker;

namespace BusinessLogicLayer.TaskManager.TaskSearching
{
    public class SearchByEditing : ISearcher
    {
        private Worker _worker;
        
        public SearchByEditing(Worker worker)
        {
            _worker = worker;
        }

        public List<Task> Search(TasksStorage tasksStorage)
        {
            return tasksStorage.Find(task => task.Log.Find(tuple => tuple.worker.Id == _worker.Id) != default);
        }
    }
}