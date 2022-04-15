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

namespace Reestr.Blazor.Component.DistrictsServices
{
    public class DistrictsComponent : ComponentBase
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
        protected DbRepository<Districts> ReestrDb { get; set; }
        protected RadzenDataGrid<Districts> grid0;

        IEnumerable<Reestr.Database.Model.Districts> _getDistrictsResult;
        protected IEnumerable<Reestr.Database.Model.Districts> getDistrictsResult
        {
            get
            {
                return _getDistrictsResult;
            }
            set
            {
                if (!object.Equals(_getDistrictsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDistrictsResult", NewValue = value, OldValue = _getDistrictsResult };
                    _getDistrictsResult = value;
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
            var reestrDbGetDistrictsResult = await ReestrDb.Get();
            getDistrictsResult = reestrDbGetDistrictsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddDistrict>("Добавить новый район", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

      
        protected async System.Threading.Tasks.Task Grid0RowSelect(Districts args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDistrict>("Edit District", new Dictionary<string, object>() { { "IdDistricts", args.IdDistricts } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDeleteDistrictResult = await ReestrDb.DeleteDistrict(data.IdDistricts);
            //        if (reestrDbDeleteDistrictResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDeleteDistrictException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete District" });
            //}
        }
    }
}
