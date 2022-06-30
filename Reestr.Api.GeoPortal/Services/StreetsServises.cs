using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Reestr.Api.GeoPortal.Infrastructure.Token;
using Reestr.Api.GeoPortal.Model;
using Reestr.Api.GeoPortal.Services.Contract;
using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Services
{
    public class StreetsServises
    {
        private readonly AuthorizationToken _authorizationToken;
        private readonly IAddressRegistryApiService _jsonConvertServise;

        public StreetsServises(
            AuthorizationToken authorizationToken,
             IAddressRegistryApiService jsonConvertServise)
        {
            _authorizationToken = authorizationToken;
            _jsonConvertServise = jsonConvertServise;
        }

        public async Task<IEnumerable<StreetsModel>> GetStreets()
        {
            string key = _authorizationToken.StringKey();
            string url = $"https://dev.geo-portal.com.ua/kharkivregister/external/api/streets";
            string fullUrl = $"{url}?key={key}";

            string resultGetString = await _jsonConvertServise.GetAddressRegistryData(fullUrl);
            var dataDistrict = JsonConvert.DeserializeObject<IEnumerable<StreetsModel>>(resultGetString);

            return dataDistrict;
        }

        public async Task<StreetsModel> GetById(int id)
        {
            string key = _authorizationToken.StringKey();
            string url = $"https://dev.geo-portal.com.ua/kharkivregister/external/api/streetById";
            string fullUrl = $"{url}?key={key}&id={id}";

            string resultGetById = await _jsonConvertServise.GetAddressRegistryData(fullUrl);
            var resultJsonConvert = JsonConvert.DeserializeObject<StreetsModel>(resultGetById);

            return resultJsonConvert;
        }

        public async Task<IEnumerable<StreetsModel>> GetOnlyValidStreetNames()
        {
            var streetAll = await GetStreets();
            var streetValid = streetAll.Where(x => x.valid == "YES");
            var resultListStreets = new List<StreetsModel>();

            foreach (var item in streetValid)
            {
                resultListStreets.Add(new StreetsModel 
                {
                    id = item.id,
                    name_ukr = StreetHistory(item, streetAll)
                });
            }

            return resultListStreets.AsEnumerable();
        }

        private string StreetHistory(StreetsModel streets,  IEnumerable<StreetsModel> streetsList)
        {
            if (streets.before != -1)
            {
                var nameStreetOld = streetsList.FirstOrDefault(x => x.id == streets.before);
                var nameStreetOldResult = $"{streets.name_ukr}, {streets.type_ukr} ({nameStreetOld.name_ukr}, {nameStreetOld.type_ukr})";

                return nameStreetOldResult;
            }
            else
            {
                var nameStreetOldResult = $"{streets.name_ukr}, {streets.type_ukr}";

                return nameStreetOldResult;
            }
        }

        public async Task<IEnumerable<StreetsModel>> HistoryStreets(int idStreets)
        {
            var getById = await GetById(idStreets);

            var listStreetHistory = new List<StreetsModel>();
            listStreetHistory.Add(getById);

            var resultStrets = await GetStreets();

            if (resultStrets.Any(x => x.before == idStreets))
            {
                var stritsById = resultStrets.Where(x => x.before == idStreets);

                foreach (var itemStreets in stritsById)
                {
                    listStreetHistory.Add(itemStreets);
                }
            }

            if (getById.before != -1)
            {
                do
                {
                    var whereBeforeId = await GetById(listStreetHistory.LastOrDefault().before.Value);
                    listStreetHistory.Add(whereBeforeId);

                } while (!listStreetHistory.Any(x => x.before == -1));
            }

            return listStreetHistory.OrderByDescending(x => x.valid);
        }

        public IEnumerable<TypeStreetsModel> GetTypeStreets(IEnumerable<StreetsModel> dataStreet)
        {
            var streetType = dataStreet
                 .GroupBy(x => x.street_type_id)
                 .Select(s => new TypeStreetsModel
                 {
                     street_type_id = s.FirstOrDefault().street_type_id.Value,
                     type_ru = s.FirstOrDefault().type_ru,
                     type_ukr = s.FirstOrDefault().type_ukr
                 });

            return streetType;
        }
    }
}
