using System.Collections.Generic;

namespace DataAccessLayer.Worker
{
    public class Worker
    {
        public int Id { get; }
        public string Name { get; }
        public Worker Boss { get; set; }
        public List<Worker> Subordinates { get; set; }
        
        private static int _idCounter;

        public Worker(string name)
        {
            Id = _idCounter++;
            Name = name;
        }
    }
}