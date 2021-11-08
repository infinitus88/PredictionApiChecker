using Microsoft.EntityFrameworkCore;
using PredictionApiChecker.Data.Access.Maps.Common;
using PredictionApiChecker.Data.Models.Football;

namespace PredictionApiChecker.Data.Access.Maps.Main.Football
{
    public class LoadingDateMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<LoadingDate>()
                .ToTable("LoadingDates")
                .HasKey(x => x.Id);
        }
    }
}