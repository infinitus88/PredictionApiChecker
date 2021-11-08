using System.Collections.Generic;
using Newtonsoft.Json;

namespace PredictionApiChecker.Api.Models.Football
{
    public class PredictionRecordModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("home_team")]
        public string HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public string AwayTeam { get; set; }

        [JsonProperty("competition_name")]
        public string CompetionName { get; set; }

        [JsonProperty("prediction")]
        public string Prediction { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_expired")]
        public bool IsExpired { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("last_update_at")]
        public string LastUpdateAt { get; set; }
        
        [JsonProperty("odds")]
        public IDictionary<string, double?> Odds { get; set; }

        public PredictionRecordModel()
        {
            Odds = new Dictionary<string, double?>();
        }
    }
}