using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Contract.GenericContract
{
    public interface IGetDb<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
