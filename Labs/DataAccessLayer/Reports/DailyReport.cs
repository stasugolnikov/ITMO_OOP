using DataAccessLayer.Abstractions;

namespace DataAccessLayer.Reports
{
    public class DailyReport : AbstractReport
    {
        public Worker.Worker Worker { get; }

        public DailyReport(Worker.Worker worker)
        {
            Worker = worker;
        }
    }
}