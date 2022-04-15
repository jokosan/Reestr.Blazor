using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Infrastructure.Repositories
{
    public interface IGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int? id);

        Task<IEnumerable<T>> GetInclude(string children);
        Task<IEnumerable<T>> GetInclude(string children, string childrenTwo);
        Task<IEnumerable<T>> GetInclude(string children, string childrenTwo, string childrenThree);

        Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children);
        Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo);
        Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo, string childrenThree);
        Task<IEnumerable<T>> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string childrenTwo, string childrenThree, string childrenFour);


        Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne);
        Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne, string childrenTwo);
        Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne, string childrenTwo, string childrenThree);
        Task<T> FirstOrDefaultAsyncInclude(Expression<Func<T, bool>> filter, string childrenOne, string childrenTwo, string childrenThree, string childrenFour);
    }
}
