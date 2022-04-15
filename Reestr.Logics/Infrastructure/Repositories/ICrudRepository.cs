using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Infrastructure.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entityToUpdate);
        void Delete(object id);
        void Delete(T entityToDelete);
    }
}
