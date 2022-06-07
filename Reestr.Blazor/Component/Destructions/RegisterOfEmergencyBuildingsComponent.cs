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
using Reestr.Blazor.Areas.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq.Dynamic.Core;
using Reestr.Api.GeoPortal.Services;
using Reestr.Api.GeoPortal.ModelView;

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

        [Inject]
        protected ApplicationDbContext dbContext { get; set; }

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
            var reestrDbGetRegisterOfEmergencyBuildingsResult = await RegisterOfEmergencyBuildingsSer.GetRegisterOfEmergencyBuildings(new Query() { Expand = "Microdistrict,BuildingType,TypeOfOwnership,PossibilityOfReconstruction,PhotographicFixation,AddressingApi" });
            getRegisterOfEmergencyBuildingsResult = reestrDbGetRegisterOfEmergencyBuildingsResult;

        }

        protected async Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddRegisterOfEmergencyBuilding>("Додати в реєстр аварійних будівель та споруд", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async Task Grid0RowSelect(DataGridRowMouseEventArgs<RegisterOfEmergencyBuildings> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditRegisterOfEmergencyBuilding>($"Редагувати | Поточна адреса {args.Data.AddressingApi?.TypeUkr} {args.Data.AddressingApi?.NameUkr} {args.Data.AddressingApi?.Number}", new Dictionary<string, object>() { { "IdRegisterOfEmergencyBuildings", args.Data.IdRegisterOfEmergencyBuildings } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

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

        //protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        //{
        //    if (args?.Value == "csv")
        //    {
        //        await RegisterOfEmergencyBuildingsSer.ExportRegisterOfEmergencyBuildingsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter) ? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "BuildingType,Microdistrict,TypeOfOwnership,AddressingApi,PhotographicFixation,PossibilityOfReconstruction", Select = "IdRegisterOfEmergencyBuildings,SectorNumber,BuildingType.NameBuildingType as BuildingTypeNameBuildingType,Microdistrict.NameMicrodistrict as MicrodistrictNameMicrodistrict,TypeOfOwnership.NameTypeOfOwnership as TypeOfOwnershipNameTypeOfOwnership,AddressingApi.Number as AddressingNumber,TypeOfDestruction,TypeBuildings,Description,JobDescription,PhotographicFixation.Url as PhotographicFixationUrl,PossibilityOfReconstruction.ScanDoc as PossibilityOfReconstructionScanDoc,Note" }, $"Register Of Emergency Buildings");

        //    }

        //    if (args == null || args.Value == "xlsx")
        //    {
        //        await RegisterOfEmergencyBuildingsSer.ExportRegisterOfEmergencyBuildingsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter) ? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "BuildingType,Microdistrict,TypeOfOwnership,AddressingApi,PhotographicFixation,PossibilityOfReconstruction", Select = "IdRegisterOfEmergencyBuildings,SectorNumber,BuildingType.NameBuildingType as BuildingTypeNameBuildingType,Microdistrict.NameMicrodistrict as MicrodistrictNameMicrodistrict,TypeOfOwnership.NameTypeOfOwnership as TypeOfOwnershipNameTypeOfOwnership,AddressingApi.Number as AddressingNumber,TypeOfDestruction,TypeBuildings,Description,JobDescription,PhotographicFixation.Url as PhotographicFixationUrl,PossibilityOfReconstruction.ScanDoc as PossibilityOfReconstructionScanDoc,Note" }, $"Register Of Emergency Buildings");

        //    }
        //}
    }
}
