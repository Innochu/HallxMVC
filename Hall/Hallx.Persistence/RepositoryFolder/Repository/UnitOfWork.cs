using Hallx.Persistence.Data;
using Hallx.Persistence.RepositoryFolder.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallx.Persistence.RepositoryFolder.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HallxDbContext _hallxDbContext;

        public UnitOfWork(HallxDbContext hallxDbContext)
        {
            _hallxDbContext = hallxDbContext;
            CategoryRepo = new CategoryRepository(_hallxDbContext);
        }
        public ICategoryRepository CategoryRepo {  get; private set; }

        public void Save()
        {
            _hallxDbContext.SaveChanges();
        }
    }
}
