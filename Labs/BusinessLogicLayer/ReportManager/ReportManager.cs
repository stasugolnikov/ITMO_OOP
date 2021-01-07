using System.Collections.Generic;
using DataAccessLayer.Abstractions;
using DataAccessLayer.Reports;
using DataAccessLayer.Worker;

namespace BusinessLogicLayer.ReportManager
{
    public class ReportManager
    {
        private ReportsStorage _reportsStorage;

        public ReportManager()
        {
            _reportsStorage = new ReportsStorage();
        }

        public DailyReport CreateDailyReport(Worker worker) => new DailyReport(worker);

        public SprintReport CreateSprintReport(Worker teamlead, List<Worker> workers) =>
            new SprintReport(teamlead, workers);

        public void LoadReport(AbstractReport report) => _reportsStorage.Add(report);
    }
}