using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using PredictionApiChecker.Data.Access.DAL.Repositories;
using PredictionApiChecker.Data.Models.Football;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PredictionApiChecker.Api.Models.Football;
using AutoMapper;
using System.Collections.Generic;

namespace PredictionApiChecker.Services.PredictionAppService
{
    public class PredictionService : IPredictionService
    {
        private readonly ILogger<PredictionService> _log;
        private readonly IGenericRepository _repository;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public PredictionService(ILogger<PredictionService> log, IGenericRepository repository, HttpClient httpClient, IMapper mapper)
        {
            _repository = repository;
            _httpClient = httpClient;
            _log = log;
            _mapper = mapper;
        }
        

        public async Task LoadRecordsByDate(DateTime date)
        {
            _log.LogInformation("Sending Get Predictions Request...");
            var loadingDate = _repository.Query<LoadingDate>().Where(d => d.LoadDate.Date == date.Date).FirstOrDefault();
            if (loadingDate != null)
                return;
            
            var records = await GetPredictionsByDate(loadingDate.LoadDate);
            if (records.Count() > 0)
            {
                _log.LogInformation("Loading Prediction for {0}", date.Date.ToString());
                await AddRecordsToDatabase(records);
            }
        }

        private async Task AddRecordsToDatabase(IList<PredictionRecordModel> recordsList)
        {
            _log.LogInformation("Mapping and saving Prediction Records to Database");
            IList<PredictionRecord> records = _mapper.Map<IList<PredictionRecord>>(recordsList);

            foreach (PredictionRecord record in records)
            {
                _repository.Add(record);
            }
            await _repository.SaveAsync();
        } 

        private async Task<IList<PredictionRecordModel>> GetPredictionsByDate(DateTime date)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://football-prediction-api.p.rapidapi.com/api/v2/predictions?market=classic&iso_date={date.ToString("yyyy-MM-dd")}&federation=UEFA")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            GetPredictionRecords predicitonRecords = JsonConvert.DeserializeObject<GetPredictionRecords>(responseContent);
            return predicitonRecords.Data.ToList();
        }

        public async Task LoadRecordsForPeriod(DateTime startDate, DateTime endDate)
        {
            var dates = GetIntermediateDatesByPeriod(startDate, endDate);

            List<PredictionRecordModel> predictionRecords = new List<PredictionRecordModel>();

            foreach (var date in dates)
            {
                var validDate = _repository.Query<LoadingDate>().Where(d => d.LoadDate.Date == date.Date).FirstOrDefault();

                if (validDate != null)
                {
                    _log.LogInformation("Prediciton records for {0} are already loaded to database!", validDate.LoadDate.ToString("dd'-'MM'-'yyyy"));
                    continue;
                }
                
                IList<PredictionRecordModel> recordsByDate = await GetPredictionsByDate(date);
                predictionRecords.AddRange(recordsByDate);
                _repository.Add(new LoadingDate { LoadDate = date, LastUpdateAt = DateTime.Now });
            }

            await AddRecordsToDatabase(predictionRecords);
        }

        private IEnumerable<DateTime> GetIntermediateDatesByPeriod(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
                .Select(offset => startDate.AddDays(offset))
                .ToArray();
        }
    }
}