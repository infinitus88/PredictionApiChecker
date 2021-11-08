using System.Linq;
using System.Threading.Tasks;

namespace PredictionApiChecker.Data.Access.DAL.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly MainDbContext _context;

        public GenericRepository(MainDbContext context)
        {
            _context = context;
        }


        public void Add<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Add(obj);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Remove<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Remove(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Attach(obj);
        }
    }
}