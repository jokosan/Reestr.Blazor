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
using Reestr.Blazor.Pages.InformationAboutDestructionPages;

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
        protected RadzenDataGrid<InformationAboutDestruction> grid1;

        [Inject]
        protected RegisterOfEmergencyBuildingsServices RegisterOfEmergencyBuildingsSer { get; set; }
        
        [Inject]
        protected InformationAboutDestructionServises InformationAboutDestructionServises { get; set; }

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

        dynamic _master;
        protected dynamic master
        {
            get
            {
                return _master;
            }
            set
            {
                if (!object.Equals(_master, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "master", NewValue = value, OldValue = _master };
                    _master = value;
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

        protected async System.Threading.Tasks.Task Grid0RowExpand(RegisterOfEmergencyBuildings args)
        {
            master = args;
             
            var reestrDbDgaGetInformationAboutDestructionsResult = await InformationAboutDestructionServises.GetInformationAboutDestructions(new Query() { Filter = $@"i => i.RegisterOfEmergencyBuildingsId == {args.IdRegisterOfEmergencyBuildings}" });
            if (reestrDbDgaGetInformationAboutDestructionsResult != null)
            {
                args.InformationAboutDestruction = reestrDbDgaGetInformationAboutDestructionsResult.ToList();
            }
        }

        protected async System.Threading.Tasks.Task InformationAboutDestructionAddButtonClick(MouseEventArgs args, dynamic data)
        {
            var dialogResult = await DialogService.OpenAsync<AddInformationAboutDestruction>("Add Information About Destruction", new Dictionary<string, object>() { { "RegisterOfEmergencyBuildingsId", data.IdRegisterOfEmergencyBuildings } });
            await Grid0RowExpand(master);

            await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(InformationAboutDestruction args, dynamic data)
        {
            var dialogResult = await DialogService.OpenAsync<EditInformationAboutDestruction>("Edit Information About Destruction", new Dictionary<string, object>() { { "IdInformationAboutDestruction", args.IdInformationAboutDestruction } });
            await Grid0RowExpand(master);

            await grid1.Reload();
        }
    }
}
