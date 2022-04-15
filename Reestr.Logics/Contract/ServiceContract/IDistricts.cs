using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Contract.ServiceContract
{
    public interface IDistricts
    {
        Task<Districts> CreateDistrict(Districts districts);
        Task<Districts> GetDistrictByIdDistricts(int? idDistricts);
        Task<Districts> UpdateDistrict(int? idDistricts, Districts district);
    }
}
