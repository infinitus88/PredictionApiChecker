using System.Linq;
using System.Threading.Tasks;

namespace PredictionApiChecker.Data.Access.DAL.Repositories
{
    public interface IGenericRepository
    {
        void Add<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        void Remove<T>(T obj) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void Save();
        Task SaveAsync();
    }
}