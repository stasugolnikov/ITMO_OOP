using System.Collections.Generic;
using DataAccessLayer.Task;

namespace BusinessLogicLayer.TaskManager.TaskSearching
{
    public interface ISearcher
    {
        List<Task> Search(TasksStorage tasksStorage);
    }
}