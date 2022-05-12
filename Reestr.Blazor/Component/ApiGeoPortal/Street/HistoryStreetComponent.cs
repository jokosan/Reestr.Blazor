using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.EntityFrameworkCore;
using Reestr.Blazor.Services;
using Reestr.Logics.Infrastructure.Repositories;
using Reestr.Database.Model;
using Reestr.Blazor.Pages;
using Reestr.Blazor.Pages.District;
using Reestr.Blazor.Pages.Urbanonymy;
using Reestr.Logics.Service;
using Reestr.Api.GeoPortal.Services;
using Reestr.Api.GeoPortal.Model;

namespace Reestr.Blazor.Component.ApiGeoPortal.Street
{
    public class HistoryStreetComponent : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected StreetsServises GetServerApi { get; set; }

        [Parameter]
        public dynamic IdStreet { get; set; }

        public IEnumerable<StreetsModel> getHistoryStreet;

        protected override async Task OnInitializedAsync()
        {
            var resultGethistoryStreet = await GetServerApi.HistoryStreets(IdStreet);
            getHistoryStreet = resultGethistoryStreet;
        }
    }
}
