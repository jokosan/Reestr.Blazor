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

namespace Reestr.Blazor.Component.Urbanonymy
{
    public class StreetsComponent : ComponentBase
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
        private StreetsService _streetsService { get; set; }

        [Inject]
        protected DbRepository<Streets> ReestrDb { get; set; }
        protected RadzenDataGrid<Streets> grid0;

        IEnumerable<Streets> _getStreetsResult;
        protected IEnumerable<Streets> getStreetsResult
        {
            get
            {
                return _getStreetsResult;
            }
            set
            {
                if (!object.Equals(_getStreetsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStreetsResult", NewValue = value, OldValue = _getStreetsResult };
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
            var reestrDbGetStreetsResult = await _streetsService.GetStreets();
            getStreetsResult = reestrDbGetStreetsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddStreet>("Add Street", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

      

        protected async System.Threading.Tasks.Task Grid0RowSelect(Streets args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStreet>("Edit Street", new Dictionary<string, object>() { { "IdStreets", args.IdStreets } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDeleteStreetResult = await ReestrDb.DeleteStreet(data.IdStreets);
            //        if (reestrDbDeleteStreetResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDeleteStreetException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete Street" });
            //}
        }
    }
}
