using DataAccessLayer.Abstractions;
using DataAccessLayer.Task;
using DataAccessLayer.Worker;

namespace BusinessLogicLayer.TaskManager.TaskSetting
{
    public class WorkerSetter : AbstractSetter
    {
        private Worker _worker;

        public WorkerSetter(Worker worker)
        {
            _worker = worker;
        }

        public override void Set(Task task, Worker worker)
        {
            task.Worker = _worker;
            CommitChanges(task, worker);
        }
    }
}