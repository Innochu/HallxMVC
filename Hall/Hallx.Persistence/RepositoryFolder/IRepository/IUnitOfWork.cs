using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallx.Persistence.RepositoryFolder.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepo { get;}
        void Save();
    }
}
