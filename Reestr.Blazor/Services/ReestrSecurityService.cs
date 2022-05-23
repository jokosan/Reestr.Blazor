using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Reestr.Blazor.Areas.Data;
using Reestr.Blazor.Areas.Identity.ViewModel;

namespace Reestr.Blazor.Services
{
    public partial class ReestrSecurityService
    {
        ApplicationDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        private readonly ApplicationDbContext context;
        private readonly NavigationManager navigationManager;

        public ReestrSecurityService(ApplicationDbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

    }
}
