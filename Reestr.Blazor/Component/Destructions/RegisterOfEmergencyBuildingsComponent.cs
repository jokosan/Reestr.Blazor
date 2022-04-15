using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reestr.Blazor.Services;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Logics.Service;
using Radzen.Blazor;
using Reestr.Blazor.Pages.Destruction;

namespace Reestr.Blazor.Component.Destructions
{
    public class RegisterOfEmergencyBuildingsComponent : ComponentBase
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
        protected UnitOfWork ReestrDb { get; set; }

        protected RadzenDataGrid<RegisterOfEmergencyBuildings> grid0;

        [Inject]
        protected RegisterOfEmergencyBuildingsServices RegisterOfEmergencyBuildingsSer { get; set; }

        IEnumerable<RegisterOfEmergencyBuildings> _getRegisterOfEmergencyBuildingsResult;

        protected IEnumerable<RegisterOfEmergencyBuildings> getRegisterOfEmergencyBuildingsResult
        {
            get
            {
                return _getRegisterOfEmergencyBuildingsResult;
            }
            set
            {
                if (!object.Equals(_getRegisterOfEmergencyBuildingsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getRegisterOfEmergencyBuildingsResult", NewValue = value, OldValue = _getRegisterOfEmergencyBuildingsResult };
                    _getRegisterOfEmergencyBuildingsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var reestrDbGetRegisterOfEmergencyBuildingsResult = await RegisterOfEmergencyBuildingsSer.GetRegisterOfEmergencyBuildings();
            getRegisterOfEmergencyBuildingsResult = reestrDbGetRegisterOfEmergencyBuildingsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddRegisterOfEmergencyBuilding>("Add Register Of Emergency Building", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RegisterOfEmergencyBuildings args)
        {
            var dialogResult = await DialogService.OpenAsync<EditRegisterOfEmergencyBuilding>("Edit Register Of Emergency Building", new Dictionary<string, object>() { { "IdRegisterOfEmergencyBuildings", args.IdRegisterOfEmergencyBuildings } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDeleteRegisterOfEmergencyBuildingResult = await ReestrDb.DeleteRegisterOfEmergencyBuilding(data.IdRegisterOfEmergencyBuildings);
            //        if (reestrDbDeleteRegisterOfEmergencyBuildingResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDeleteRegisterOfEmergencyBuildingException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete RegisterOfEmergencyBuilding" });
            //}
        }
    }
}
