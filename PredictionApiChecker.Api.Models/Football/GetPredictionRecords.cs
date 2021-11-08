using System.Collections.Generic;
using Newtonsoft.Json;

namespace PredictionApiChecker.Api.Models.Football
{
    public class GetPredictionRecords
    {
        [JsonProperty("data")]
        public IList<PredictionRecordModel> Data { get; set; }

        public GetPredictionRecords() 
        {
            Data = new List<PredictionRecordModel>();
        }
    }
}