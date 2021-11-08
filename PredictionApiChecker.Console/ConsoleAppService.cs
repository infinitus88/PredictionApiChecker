using System.Globalization;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PredictionApiChecker.Services.PredictionAppService;

namespace PredictionApiChecker.Console
{
    public class ConsoleAppService
    {
        private readonly ILogger<ConsoleAppService> _log;
        private readonly IPredictionService _predictionService;

        public ConsoleAppService(ILogger<ConsoleAppService> log, IPredictionService predictionService)
        {
            _log = log;
            _predictionService = predictionService;
        }

        public async Task Run()
        {
            _log.LogInformation("Application Start");
            // await _predictionService.LoadRecordsByDate(DateTime.Now);

            var startDate = DateTime.ParseExact("2018-10-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact("2018-10-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            await _predictionService.LoadRecordsForPeriod(startDate, endDate);
        }
    }
}