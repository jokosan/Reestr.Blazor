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
    }
}
