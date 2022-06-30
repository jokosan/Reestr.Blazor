using Microsoft.Extensions.Caching.Memory;
using Reestr.Api.GeoPortal.Infrastructure.Cache;
using Reestr.Api.GeoPortal.Model;
using Reestr.Api.GeoPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Services
{
    public class CacheStreetsSService
    {
        private readonly StreetsServises _streetsServises;
        private readonly ICacheProvider _cacheProvider;

        private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);

        public CacheStreetsSService(StreetsServises streetsServises, ICacheProvider cacheProvider)
        {
            _streetsServises = streetsServises;
            _cacheProvider = cacheProvider;
        }

        public async Task<IEnumerable<StreetsModel>> GetStreetsCached()
        {
            return await GetCachedResponse(CacheKeys.Users, () => _streetsServises.GetStreets());
        }

        public async Task<IEnumerable<StreetsModel>> GetUsersAsync()
        {
            return await GetCachedResponse(CacheKeys.Users, GetUsersSemaphore, () => _streetsServises.GetOnlyValidStreetNames());
        }

        private async Task<IEnumerable<StreetsModel>> GetCachedResponse(string cacheKey, Func<Task<IEnumerable<StreetsModel>>> func)
        {
            var users = _cacheProvider.GetFromCache<IEnumerable<StreetsModel>>(cacheKey);
            if (users != null) return users;

            // Key not in cache, so get data.
            users = await func();

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(1));

            _cacheProvider.SetCache(cacheKey, users, cacheEntryOptions);

            return users;
        }

        private async Task<IEnumerable<StreetsModel>> GetCachedResponse(string cacheKey, SemaphoreSlim semaphore, Func<Task<IEnumerable<StreetsModel>>> func)
        {
            var users = _cacheProvider.GetFromCache<IEnumerable<StreetsModel>>(cacheKey);

            if (users != null) return users;
           
            try
            {
                await semaphore.WaitAsync();
                users = _cacheProvider.GetFromCache<IEnumerable<StreetsModel>>(cacheKey); // Recheck to make sure it didn't populate before entering semaphore
                if (users != null)
                {
                    return users;
                }
                users = await func();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

                _cacheProvider.SetCache(cacheKey, users, cacheEntryOptions);
            }
            finally
            {
                semaphore.Release();
            }

            return users;
        }
    }
}