using Microsoft.EntityFrameworkCore;
using PredictionApiChecker.Data.Access.Maps.Common;
using PredictionApiChecker.Data.Models.Football;

namespace PredictionApiChecker.Data.Access.Maps.Main.Football
{
    public class PredictionOddMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<PredictionOdd>()
                .ToTable("PredicitonOdds")
                .HasKey(x => x.Id);
        }
    }
}