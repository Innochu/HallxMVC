using Hallx.Domain.Models;
using Hallx.Persistence.Data;
using Hallx.Persistence.RepositoryFolder.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallx.Persistence.RepositoryFolder.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly HallxDbContext _hallxDbContext;

        public ProductRepository(HallxDbContext hallxDbContext) : base(hallxDbContext)
        {
            _hallxDbContext = hallxDbContext;
        }


        public void Update(Product product)
        {
            _hallxDbContext.Products.Update(product);
        }
    }
}
