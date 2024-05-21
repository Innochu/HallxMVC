using Hallx.Domain.Models;
using Hallx.Persistence.Data;
using Hallx.Persistence.RepositoryFolder.IRepository;

namespace Hallx.Persistence.RepositoryFolder.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly HallxDbContext _hallxDbContext;

        public CategoryRepository(HallxDbContext hallxDbContext) : base(hallxDbContext) 
        {
            _hallxDbContext = hallxDbContext;
        }
       

        public void Update(Category category)
        {
           _hallxDbContext.Categories.Update(category);
        }
    }
}
