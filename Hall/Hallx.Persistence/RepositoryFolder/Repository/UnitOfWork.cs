using Hallx.Persistence.Data;
using Hallx.Persistence.RepositoryFolder.IRepository;

namespace Hallx.Persistence.RepositoryFolder.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HallxDbContext _hallxDbContext;

        public UnitOfWork(HallxDbContext hallxDbContext)
        {
            _hallxDbContext = hallxDbContext;
            CategoryRepo = new CategoryRepository(_hallxDbContext);
            ProductRepo = new ProductRepository(_hallxDbContext);
        }
        public ICategoryRepository CategoryRepo {  get; private set; }
        public IProductRepository ProductRepo {  get; private set; }

        public void Save()
        {
            _hallxDbContext.SaveChanges();
        }
    }
}
