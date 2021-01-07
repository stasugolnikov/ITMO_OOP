using System.Collections.Generic;
using DataAccessLayer.Abstractions;

namespace DataAccessLayer.Reports
{
    public class SprintReport : AbstractReport
    {
        public Worker.Worker Teamlead { get; }
        public List<Worker.Worker> Team { get; }

        public SprintReport(Worker.Worker teamlead, List<Worker.Worker> team)
        {
            Teamlead = teamlead;
            Team = team;
        }
    }
}