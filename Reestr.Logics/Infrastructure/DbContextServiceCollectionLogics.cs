using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reestr.Database.Infrastructure;

namespace Reestr.Logics.Infrastructure
{
    public class DbContextServiceCollectionLogics
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            DbContextServiceCollectionDb.Initialize(services, connectionString);
        }
    }
}
