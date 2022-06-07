using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Radzen;
using Reestr.Blazor.Component.DistrictsServices;
using Reestr.Logics.Infrastructure;
using Reestr.Logics.Infrastructure.AutoMapper;
using Reestr.Logics.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reestr.Api.GeoPortal.Infrastructure.DependencyInjection;
using Reestr.Blazor.Areas.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Reestr.Blazor.Infrastructure.DependencyInjection;
using System.Net.Http;

namespace Reestr.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SecurityDb"));
            }, ServiceLifetime.Transient);


            services.AddHttpContextAccessor();
            services.AddScoped<HttpClient>(serviceProvider =>
            {

                var uriHelper = serviceProvider.GetRequiredService<NavigationManager>();

                return new HttpClient
                {
                    BaseAddress = new Uri(uriHelper.BaseUri)
                };
            });

            services.AddHttpClient();


            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAutoMapper(typeof(AppMappingProfile));

            DependencyInjectionLogics.Initialize(services);
            DependencyInjectionLogicsGeoPortal.Initialize(services);
            IdentityConfigureServices.Initialize(services);

            DbContextServiceCollectionLogics.Initialize(services, Configuration.GetConnectionString("ReestrDb"));

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            //services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<AddDistrictComponent>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext identityDbContext)
        {
            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    return next();
                });
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            identityDbContext.Database.Migrate();

        }
    }
}
