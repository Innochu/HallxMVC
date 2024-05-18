using Hallx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallx.Persistence.RepositoryFolder.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        void Update(Category category);
      
    }
}
