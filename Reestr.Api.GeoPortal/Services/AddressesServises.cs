using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Reestr.Api.GeoPortal.Infrastructure.Token;
using Reestr.Api.GeoPortal.Model;
using Reestr.Api.GeoPortal.ModelView;
using Reestr.Api.GeoPortal.Services.Contract;
using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Services
{
    public class AddressesServises
    {
        private readonly AuthorizationToken _authorizationToken;
        private readonly IAddressRegistryApiService _jsonConvertServise;

        public AddressesServises(
            AuthorizationToken authorizationToken,
             IAddressRegistryApiService jsonConvertServise)
        {
            _authorizationToken = authorizationToken;
            _jsonConvertServise = jsonConvertServise;
        }

        public async Task<IEnumerable<AddressesModel>> AddressesAllByStreetsId(int streetId = 0)
        {
            if (streetId != 0)
            {
                string key = _authorizationToken.StringKey();
                string url = $"https://dev.geo-portal.com.ua/kharkivregister/external/api/addresses";
                string fullUrl = $"{url}?key={key}&streetid={streetId}";

                string resultAddrsee = await _jsonConvertServise.GetAddressRegistryData(fullUrl);
                var resultAddressesAllByStreetsId = JsonConvert.DeserializeObject<IEnumerable<AddressesModel>>(resultAddrsee);

                return resultAddressesAllByStreetsId;
            }
            else
            {
                return null;
            }
        }

        public async Task<AddressesModel> GetById(int id)
        {
            string key = _authorizationToken.StringKey();
            string url = $"https://dev.geo-portal.com.ua/kharkivregister/external/api/addressById";
            string fullUrl = $"{url}?key={key}&id={id}";

            string resultAddrsee = await _jsonConvertServise.GetAddressRegistryData(fullUrl);
            var resultAddress = JsonConvert.DeserializeObject<AddressesModel>(resultAddrsee);

            return resultAddress;
        }

        public async Task<AddressingApi> AddressesModelMap(int id)
        {
            var resultGetById = await GetById(id);

            AddressingApi addressing = new AddressingApi();

            addressing.IdAddressingApi = resultGetById.id;
            addressing.Lat = resultGetById.lat;
            addressing.Longi = resultGetById.longi;
            addressing.NameUkr = resultGetById.name_ukr;
            addressing.Number = resultGetById.number;
            addressing.Postcode = resultGetById.postcode;
            addressing.RegDate = Convert.ToDateTime(resultGetById.reg_date);
            addressing.SameAddrComm = resultGetById.same_addr_comm;
            addressing.Streetid = resultGetById.streetid;
            addressing.Suffix = resultGetById.suffix;
            addressing.TypeUkr = resultGetById.type_ukr;
            addressing.Valid = resultGetById.valid == "YES" ? true : false;
            addressing.Block = resultGetById.block;
            addressing.Detail = resultGetById.detail;
            addressing.DetailNumber = resultGetById.detail_number;
            addressing.DetailUa = resultGetById.detail_ua;
            addressing.DistrictId = resultGetById.districtId;
            addressing.DistrictUa = resultGetById.district_ua;

            return addressing;
        }
    }
}
