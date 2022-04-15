using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reestr.Database.Context;

namespace Reestr.Database.Infrastructure
{
    public class DbContextServiceCollectionDb
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContextReestr>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
