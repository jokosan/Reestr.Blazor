using Microsoft.Extensions.Logging;
using Reestr.Api.GeoPortal.Model;
using Reestr.Api.GeoPortal.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Services
{
    public class AddressRegistryApiService : IAddressRegistryApiService
    {
        public async Task<string> GetAddressRegistryData(string url)
        {
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var stringGetAddressRegistryData = result.Content.ReadAsStringAsync();
                    stringGetAddressRegistryData.Wait();
                   return stringGetAddressRegistryData.Result;
                }
                else
                {
                    throw new HttpRequestException(result.ReasonPhrase);
                }

            }
        }
    }
}
