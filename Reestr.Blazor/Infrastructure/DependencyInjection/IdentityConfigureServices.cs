using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using Reestr.Blazor.Areas.Data;
using Reestr.Blazor.Areas.Identity.ViewModel;
using Reestr.Blazor.Authentication;
using Reestr.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Reestr.Blazor.Infrastructure.DependencyInjection
{
    public class IdentityConfigureServices
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddAuthorization();


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                  ApplicationPrincipalFactory>();
           
            services.AddScoped<SecurityService>();
            services.AddScoped<ReestrSecurityService>();
            services.AddScoped<GlobalsService>();
        }
    }
}
