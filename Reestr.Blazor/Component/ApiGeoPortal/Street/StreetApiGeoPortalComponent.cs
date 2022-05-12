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
    public class StreetApiGeoPortalComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

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

        protected RadzenDataGrid<StreetsModel> grid0;

        IEnumerable<StreetsModel> _getStreetsResult;

        protected IEnumerable<StreetsModel> getStreetsResult
        { 
            get
            {
                return _getStreetsResult;
            }
            set
            {
                if (!object.Equals(_getStreetsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStreetCategoriesResult", NewValue = value, OldValue = _getStreetsResult };
                    _getStreetsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        protected async Task Load()
        {
            var reestrDbGetStreetCategoriesResult = await GetServerApi.GetStreets();
            getStreetsResult = reestrDbGetStreetCategoriesResult;
        }

        protected async Task SelectHistoryStreets(DataGridRowMouseEventArgs<StreetsModel> args)
        {
            var dialogResult = await DialogService.OpenAsync<HistoryStreets>("", new Dictionary<string, object>() { { "IdStreet", args.Data.id } }, new DialogOptions() { Width = "800px" });
            await grid0.Reload();
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
