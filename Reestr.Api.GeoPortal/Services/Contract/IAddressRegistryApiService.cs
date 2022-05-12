using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Services.Contract
{
    public interface IAddressRegistryApiService
    {
        Task<string> GetAddressRegistryData(string url);
    }
}
