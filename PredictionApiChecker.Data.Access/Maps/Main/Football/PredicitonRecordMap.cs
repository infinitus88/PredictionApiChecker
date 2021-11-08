using Microsoft.EntityFrameworkCore;
using PredictionApiChecker.Data.Access.Maps.Common;
using PredictionApiChecker.Data.Models.Football;

namespace PredictionApiChecker.Data.Access.Maps.Main.Football
{
    public class PredictionRecordMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<PredictionRecord>()
                .ToTable("PredictionRecords")
                .HasKey(x => x.Id);
        }
    }
}