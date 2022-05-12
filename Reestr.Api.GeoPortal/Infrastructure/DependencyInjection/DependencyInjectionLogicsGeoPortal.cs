using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;
using Reestr.Api.GeoPortal.Services;
using Reestr.Api.GeoPortal.Infrastructure.Token;
using System.Net.Http;
using Reestr.Api.GeoPortal.Services.Contract;

namespace Reestr.Api.GeoPortal.Infrastructure.DependencyInjection
{
    public class DependencyInjectionLogicsGeoPortal
    {
        public static void Initialize(IServiceCollection services)
        {
            // services.AddHttpClient("AddressRegistryApi", c => c.BaseAddress = new Uri("https://dev.geo-portal.com.ua/kharkivregister/external/api/"));
            services.AddHttpClient<IAddressRegistryApiService, AddressRegistryApiService>("AddressRegistryApi", c => c.BaseAddress = new Uri("https://dev.geo-portal.com.ua/kharkivregister/external/api/"))
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            services.AddScoped<DistrictServises>();
            services.AddScoped<AuthorizationToken>();       
            services.AddScoped<StreetsServises>();
           
           services.AddScoped<IAddressRegistryApiService, AddressRegistryApiService>();
        }
    }
}
