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

namespace Reestr.Blazor.Component.Destructions
{
    public class AddRegisterOfEmergencyBuildingsComponent : ComponentBase
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
        protected RegisterOfEmergencyBuildingsServices RegisterOfEmergencyBuildingsSer { get; set; }

        [Inject]
        protected UnitOfWork ReestrDb { get; set; }

        IEnumerable<Addressing> _getAddressingsResult;

        protected IEnumerable<Addressing> getAddressingsResult
        {
            get
            {
                return _getAddressingsResult;
            }
            set
            {
                if (!object.Equals(_getAddressingsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getAddressingsResult", NewValue = value, OldValue = _getAddressingsResult };
                    _getAddressingsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

      

        RegisterOfEmergencyBuildings _registerofemergencybuilding;

        public RegisterOfEmergencyBuildings registerofemergencybuilding
        {
            get
            {
                return _registerofemergencybuilding;
            }
            set
            {
                if (!object.Equals(_registerofemergencybuilding, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "registerofemergencybuilding", NewValue = value, OldValue = _registerofemergencybuilding };
                    _registerofemergencybuilding = value;
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
            var reestrDbGetAddressingsResult = await ReestrDb.AddressingUnitOfWork.Get();
            getAddressingsResult = reestrDbGetAddressingsResult;

            getStreetCategoriesResult = await ReestrDb.StreetCategoryUnitOfWork.Get();
            getStreetResult = await ReestrDb.StreetsUnitOfWork.Get();

            registerofemergencybuilding = new RegisterOfEmergencyBuildings() { };
        }

        public async System.Threading.Tasks.Task Form0Submit(RegisterOfEmergencyBuildings args)
        {
            try
            {
                var reestrDbCreateRegisterOfEmergencyBuildingResult = await RegisterOfEmergencyBuildingsSer.CreateRegisterOfEmergencyBuilding(registerofemergencybuilding);
                DialogService.Close(registerofemergencybuilding);
            }
            catch (System.Exception reestrDbCreateRegisterOfEmergencyBuildingException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new RegisterOfEmergencyBuilding!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        #region 
      

        public int streetCategoriesId;
        public int streetId;

        #endregion


        public IEnumerable<StreetCategory> _getStreetCategoriesResult;

        protected IEnumerable<StreetCategory> getStreetCategoriesResult
        {
            get
            {
                return _getStreetCategoriesResult;
            }
            set
            {
                if (!object.Equals(_getAddressingsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStreetCategoriesResult", NewValue = value, OldValue = _getStreetCategoriesResult };
                    _getStreetCategoriesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public IEnumerable<Streets> _getStreetResult;

        protected IEnumerable<Streets> getStreetResult
        {
            get
            {
                return _getStreetResult;
            }
            set
            {
                if (!object.Equals(_getAddressingsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStreetResult", NewValue = value, OldValue = _getStreetResult };
                    _getStreetResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
    }
}
