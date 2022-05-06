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
using Reestr.Logics.Modul.Upload;

namespace Reestr.Blazor.Component.Destructions
{
    public class EditRegisterOfEmergencyBuildingsComponent : ComponentBase
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
        protected PhotographicFixationServices PhotographicFixationService { get; set; }

        [Inject]
        protected RegisterOfEmergencyBuildingsServices RegisterOfEmergencyBuildingsSer { get; set; }
        [Inject]
        protected AddressingServices AddressingService { get; set; }

        [Parameter]
        public dynamic IdRegisterOfEmergencyBuildings { get; set; }

        RegisterOfEmergencyBuildings _registerofemergencybuilding;

        protected RegisterOfEmergencyBuildings registerofemergencybuilding
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


        IEnumerable<Microdistrict> _getMicrodistrictsForMicrodistrictIdResult;
        protected IEnumerable<Microdistrict> getMicrodistrictsForMicrodistrictIdResult
        {
            get
            {
                return _getMicrodistrictsForMicrodistrictIdResult;
            }
            set
            {
                if (!object.Equals(_getMicrodistrictsForMicrodistrictIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getMicrodistrictsForMicrodistrictIdResult", NewValue = value, OldValue = _getMicrodistrictsForMicrodistrictIdResult };
                    _getMicrodistrictsForMicrodistrictIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<BuildingType> _getBuildingTypesForBuildingTypeIdResult;
        protected IEnumerable<BuildingType> getBuildingTypesForBuildingTypeIdResult
        {
            get
            {
                return _getBuildingTypesForBuildingTypeIdResult;
            }
            set
            {
                if (!object.Equals(_getBuildingTypesForBuildingTypeIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getBuildingTypesForBuildingTypeIdResult", NewValue = value, OldValue = _getBuildingTypesForBuildingTypeIdResult };
                    _getBuildingTypesForBuildingTypeIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TypeOfOwnership> _getTypeOfOwnershipsForTypeOfOwnershipIdResult;
        protected IEnumerable<TypeOfOwnership> getTypeOfOwnershipsForTypeOfOwnershipIdResult
        {
            get
            {
                return _getTypeOfOwnershipsForTypeOfOwnershipIdResult;
            }
            set
            {
                if (!object.Equals(_getTypeOfOwnershipsForTypeOfOwnershipIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTypeOfOwnershipsForTypeOfOwnershipIdResult", NewValue = value, OldValue = _getTypeOfOwnershipsForTypeOfOwnershipIdResult };
                    _getTypeOfOwnershipsForTypeOfOwnershipIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Addressing> _getAddressingsForAddressingIdResult;
        protected IEnumerable<Addressing> getAddressingsForAddressingIdResult
        {
            get
            {
                return _getAddressingsForAddressingIdResult;
            }
            set
            {
                if (!object.Equals(_getAddressingsForAddressingIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getAddressingsForAddressingIdResult", NewValue = value, OldValue = _getAddressingsForAddressingIdResult };
                    _getAddressingsForAddressingIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }


        IEnumerable<PossibilityOfReconstruction> _getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult;
        protected IEnumerable<PossibilityOfReconstruction> getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult
        {
            get
            {
                return _getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult;
            }
            set
            {
                if (!object.Equals(_getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult", NewValue = value, OldValue = _getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult };
                    _getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult = value;
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
            var reestrDbGetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildingsResult = await RegisterOfEmergencyBuildingsSer.GetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildings(IdRegisterOfEmergencyBuildings);
            registerofemergencybuilding = reestrDbGetRegisterOfEmergencyBuildingByIdRegisterOfEmergencyBuildingsResult;

            var reestrDbDgaGetMicrodistrictsResult = await ReestrDb.MicrodistrictUnitOfWork.Get();
            getMicrodistrictsForMicrodistrictIdResult = reestrDbDgaGetMicrodistrictsResult;

            var reestrDbDgaGetBuildingTypesResult = await ReestrDb.BuildingTypeUnitOfWork.Get();
            getBuildingTypesForBuildingTypeIdResult = reestrDbDgaGetBuildingTypesResult;

            var reestrDbDgaGetTypeOfOwnershipsResult = await ReestrDb.TypeOfOwnershipUnitOfWork.Get();
            getTypeOfOwnershipsForTypeOfOwnershipIdResult = reestrDbDgaGetTypeOfOwnershipsResult;

            var reestrDbDgaGetAddressingsResult = await AddressingService.GetAddressings();
            getAddressingsForAddressingIdResult = reestrDbDgaGetAddressingsResult;

            var reestrDbDgaGetPossibilityOfReconstructionsResult = await ReestrDb.PossibilityOfReconstructionUnitOfWork.Get();
            getPossibilityOfReconstructionsForPossibilityOfReconstructionIdResult = reestrDbDgaGetPossibilityOfReconstructionsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RegisterOfEmergencyBuildings  args)
        {
            try
            {
                var reestrDbUpdateRegisterOfEmergencyBuildingResult = await RegisterOfEmergencyBuildingsSer.UpdateRegisterOfEmergencyBuilding(IdRegisterOfEmergencyBuildings, registerofemergencybuilding);

                foreach (var item in UploadSaveModel.UploadList)
                {
                    PhotographicFixation photographicFixation = new PhotographicFixation();

                    photographicFixation.RegisterOfEmergencyBuildingsId = reestrDbUpdateRegisterOfEmergencyBuildingResult.IdRegisterOfEmergencyBuildings;
                    photographicFixation.Url = item;

                    await PhotographicFixationService.CreateAddressing(photographicFixation);
                }

                UploadSaveModel.UploadList.Clear();
                DialogService.Close(registerofemergencybuilding);
            }
            catch (System.Exception reestrDbUpdateRegisterOfEmergencyBuildingException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update RegisterOfEmergencyBuilding" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected int progress;
        protected string info;

        protected void OnProgress(UploadProgressArgs args, string name)
        {
            this.info = $"% '{name}' / Loaded: {args.Loaded},  of {args.Total} bytes.";
            this.progress = args.Progress;
        }
    }
}
