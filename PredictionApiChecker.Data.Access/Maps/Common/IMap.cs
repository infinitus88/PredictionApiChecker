using Microsoft.EntityFrameworkCore;

namespace PredictionApiChecker.Data.Access.Maps.Common
{
    public interface IMap
    {
        void Visit(ModelBuilder builder);
    }
}