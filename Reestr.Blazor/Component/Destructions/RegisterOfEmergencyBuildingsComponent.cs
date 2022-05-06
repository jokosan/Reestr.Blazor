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

        protected int countRegisterOfEmergencyBuildings { get; set; }
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

        protected async Task Load()
        {
            var reestrDbGetRegisterOfEmergencyBuildingsResult = await RegisterOfEmergencyBuildingsSer.GetRegisterOfEmergencyBuildings(new Query() { Expand = "Microdistrict,BuildingType,TypeOfOwnership,Addressing,Addressing.Streets,Addressing.Streets.StreetCategory,PossibilityOfReconstruction,PhotographicFixation" });
            getRegisterOfEmergencyBuildingsResult = reestrDbGetRegisterOfEmergencyBuildingsResult;

            countRegisterOfEmergencyBuildings = getRegisterOfEmergencyBuildingsResult.Count();
        }

        protected async Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddRegisterOfEmergencyBuilding>("Додати в реєстр аварійних будівель та споруд", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task Grid0RowSelect(DataGridRowMouseEventArgs<RegisterOfEmergencyBuildings> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditRegisterOfEmergencyBuilding>("Редагувати реєстр аварійних будівель та споруд", new Dictionary<string, object>() { { "IdRegisterOfEmergencyBuildings", args.Data.IdRegisterOfEmergencyBuildings } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        //protected async Task ButtonClickImgPage( int data)
        //{
        //    UriHelper.NavigateTo($"/destruction/photographic-fixation/{data}");
        //}

        protected async Task ButtonClickImgPage(int data)
        {
            var dialogResult = await DialogService.OpenAsync<Pages.Destruction.PhotographicFixation>("", new Dictionary<string, object>() { { "Id", data } }, new DialogOptions() { Width = "800px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task ButtonSratisticClick()
        {
            var dialogResult = await DialogService.OpenAsync<Pages.Destruction.Statistics>("Аналітичний звіт", null, new DialogOptions() { Width = "1000px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
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
