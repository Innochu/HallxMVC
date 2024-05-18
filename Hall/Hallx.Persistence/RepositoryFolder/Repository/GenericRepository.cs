using Hallx.Persistence.Data;
using Hallx.Persistence.RepositoryFolder.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hallx.Persistence.RepositoryFolder.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HallxDbContext _hallxDbContext;
        internal DbSet<T> dbSet;
        public GenericRepository(HallxDbContext hallxDbContext)
        {
            _hallxDbContext = hallxDbContext;
            dbSet = _hallxDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
