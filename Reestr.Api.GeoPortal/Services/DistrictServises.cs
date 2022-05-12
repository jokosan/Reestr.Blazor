using Newtonsoft.Json;
using Reestr.Api.GeoPortal.Infrastructure.Token;
using Reestr.Api.GeoPortal.Model;
using Reestr.Api.GeoPortal.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Services
{
    public class DistrictServises
    {
        private readonly AuthorizationToken _authorizationToken;
        private readonly IAddressRegistryApiService _jsonConvertServise;

        public DistrictServises(
            AuthorizationToken authorizationToken,
             IAddressRegistryApiService jsonConvertServise)
        {
            _authorizationToken = authorizationToken;
            _jsonConvertServise = jsonConvertServise;
        }

        public async Task<List<DistrictModel>> GetDistrict()
        {
            string key = _authorizationToken.StringKey();
            string url = $"https://dev.geo-portal.com.ua/kharkivregister/external/api/district";
            string fullUrl = $"{url}?key={key}";

            string resultGetString = await _jsonConvertServise.GetAddressRegistryData(fullUrl);
            var dataDistrict = JsonConvert.DeserializeObject<List<DistrictModel>>(resultGetString);

            return dataDistrict;
        }
    }
}
