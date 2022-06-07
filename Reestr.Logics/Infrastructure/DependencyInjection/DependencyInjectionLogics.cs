using Microsoft.Extensions.DependencyInjection;
using Reestr.Database.Model;
using Reestr.Database.Infrastructure;
using Reestr.Logics.Contract.ServiceContract;
using Reestr.Logics.Infrastructure.Repositories;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Logics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reestr.Logics.Modul.GoeJson;

namespace Reestr.Logics.Infrastructure.DependencyInjection
{
    public class DependencyInjectionLogics
    {
        public static void Initialize(IServiceCollection services)
        {
            DependencyInjectionDatabase.Initialize(services);

            //DbRepository

            services.AddScoped<DbRepository<Districts>>();
            services.AddScoped<DbRepository<Land>>();
            services.AddScoped<DbRepository<StreetCategory>>();
            services.AddScoped<DbRepository<RegisterOfEmergencyBuildings>>();
            services.AddScoped<DbRepository<Solution>>();
            services.AddScoped<DbRepository<PhotographicFixation>>();
            
            // Servises

            services.AddScoped<DistrictsServises>();
            services.AddScoped<SolutionServises>();
            services.AddScoped<StreetCategoriesServises>();
            services.AddScoped<RegisterOfEmergencyBuildingsServices>();
            services.AddScoped<AddressingApiServices>();
            services.AddScoped<PhotographicFixationServises>();

     

            // UnitOFWork
            services.AddScoped<UnitOfWork>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
