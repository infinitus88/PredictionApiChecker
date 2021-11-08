using System.Collections.Generic;
using System;

namespace PredictionApiChecker.Data.Models.Football
{
    public class PredictionRecord
    {
        public long Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string CompetionName { get; set; }

        public OddType Prediction { get; set; }

        public double? PredictionCoefficient { get; set; }

        public Status Status { get; set; }

        public string Result { get; set; }

        public bool IsExpired { get; set; }

        public bool IsUpdated { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime LastUpdateAt { get; set; }
    }
}
