using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace PredictionApiChecker.Services.PredictionAppService
{
    public interface IPredictionService
    {
        Task LoadRecordsByDate(DateTime startDate);
        Task LoadRecordsForPeriod(DateTime startDate, DateTime endDate);
    }
}