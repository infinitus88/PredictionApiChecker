namespace PredictionApiChecker.Data.Models.Football
{
    public class PredictionOdd
    {
        public long Id { get; set; }
        public long PredictionRecordId { get; set; }
        public OddType OddType { get; set; }
        public double Coefficient { get; set; }
    }
}