using System.Collections.Generic;
using DataAccessLayer.Task;

namespace BusinessLogicLayer.TaskManager.TaskSearching
{
    public class SearcherById : ISearcher
    {
        private int _id;

        public SearcherById(int id)
        {
            _id = id;
        }

        public List<Task> Search(TasksStorage tasksStorage)
        {
            return tasksStorage.Find(task => task.Id == _id);
        }
    }
}