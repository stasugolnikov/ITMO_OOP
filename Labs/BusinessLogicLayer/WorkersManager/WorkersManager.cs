using System.Collections.Generic;
using DataAccessLayer.Worker;

namespace BusinessLogicLayer.WorkersManager
{
    public class WorkersManager
    {
        private WorkersStorage _workersStorage;

        public WorkersManager()
        {
            _workersStorage = new WorkersStorage();
        }

        public Worker CreateWorker(string name) => new Worker(name);

        public void AddWorker(Worker worker) => _workersStorage.Add(worker);

        public bool RemoveWorker(Worker worker) => _workersStorage.Remove(worker);

        public List<Worker> GetAll() => _workersStorage.Data;

        public void SetBoss(Worker worker, Worker newBoss)
        {
            var w = _workersStorage.Data.Find(worker1 => worker.Id == worker1.Id);
            if (w != null) w.Boss = newBoss;
        }
    }
}