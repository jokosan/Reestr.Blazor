using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using Reestr.Blazor.Services;
using System.Linq;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using System.Threading.Tasks;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Database.Model;
using Radzen.Blazor;
using Reestr.Blazor.Pages.Solutions;
using Reestr.Logics.Service;

namespace Reestr.Blazor.Component.TownPlanningRegister
{
    public class EditUrbanPlanningConditionComponent : ComponentBase
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
        protected UrbanPlanningConditionServises urbanPlanningConditionServises { get; set; }

        [Inject]
        protected IUnitOfWork UnitOfWork { get; set; }

        [Parameter]
        public dynamic IdUrbanPlanningConditions { get; set; }

        bool _hasChanges;
        protected bool hasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                if (!object.Equals(_hasChanges, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "hasChanges", NewValue = value, OldValue = _hasChanges };
                    _hasChanges = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if (!object.Equals(_canEdit, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "canEdit", NewValue = value, OldValue = _canEdit };
                    _canEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

       UrbanPlanningConditions _urbanplanningcondition;
        protected UrbanPlanningConditions urbanplanningcondition
        {
            get
            {
                return _urbanplanningcondition;
            }
            set
            {
                if (!object.Equals(_urbanplanningcondition, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "urbanplanningcondition", NewValue = value, OldValue = _urbanplanningcondition };
                    _urbanplanningcondition = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Land> _getLandsForLandIdResult;
        protected IEnumerable<Land> getLandsForLandIdResult
        {
            get
            {
                return _getLandsForLandIdResult;
            }
            set
            {
                if (!object.Equals(_getLandsForLandIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getLandsForLandIdResult", NewValue = value, OldValue = _getLandsForLandIdResult };
                    _getLandsForLandIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<DocumentStatus> _getDocumentStatusesForDocumentStatusIdResult;
        protected IEnumerable<DocumentStatus> getDocumentStatusesForDocumentStatusIdResult
        {
            get
            {
                return _getDocumentStatusesForDocumentStatusIdResult;
            }
            set
            {
                if (!object.Equals(_getDocumentStatusesForDocumentStatusIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDocumentStatusesForDocumentStatusIdResult", NewValue = value, OldValue = _getDocumentStatusesForDocumentStatusIdResult };
                    _getDocumentStatusesForDocumentStatusIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TypeOfConstruction> _getTypeOfConstructionsForTypeOfConstructionIdResult;
        protected IEnumerable<TypeOfConstruction> getTypeOfConstructionsForTypeOfConstructionIdResult
        {
            get
            {
                return _getTypeOfConstructionsForTypeOfConstructionIdResult;
            }
            set
            {
                if (!object.Equals(_getTypeOfConstructionsForTypeOfConstructionIdResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTypeOfConstructionsForTypeOfConstructionIdResult", NewValue = value, OldValue = _getTypeOfConstructionsForTypeOfConstructionIdResult };
                    _getTypeOfConstructionsForTypeOfConstructionIdResult = value;
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
            hasChanges = false;

            canEdit = true;

            var reestrDbDgaGetUrbanPlanningConditionByIdUrbanPlanningConditionsResult = await urbanPlanningConditionServises.GetUrbanPlanningConditionByIdUrbanPlanningConditions(IdUrbanPlanningConditions);
            urbanplanningcondition = reestrDbDgaGetUrbanPlanningConditionByIdUrbanPlanningConditionsResult;

            var reestrDbDgaGetLandsResult = await UnitOfWork.LandUnitOfWork.Get();
            getLandsForLandIdResult = reestrDbDgaGetLandsResult;

            var reestrDbDgaGetDocumentStatusesResult = await UnitOfWork.DocumentStatusUnitOfWork.Get();
            getDocumentStatusesForDocumentStatusIdResult = reestrDbDgaGetDocumentStatusesResult;

            var reestrDbDgaGetTypeOfConstructionsResult = await UnitOfWork.TypeOfConstructionUnitOfWork.Get();
            getTypeOfConstructionsForTypeOfConstructionIdResult = reestrDbDgaGetTypeOfConstructionsResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            urbanPlanningConditionServises.Reset();

            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(UrbanPlanningConditions args)
        {
            //try
            //{
            //    var reestrDbDgaUpdateUrbanPlanningConditionResult = await ReestrDbDga.UpdateUrbanPlanningCondition(int.Parse($"{IdUrbanPlanningConditions}"), urbanplanningcondition);
            //    DialogService.Close(urbanplanningcondition);
            //}
            //catch (System.Exception reestrDbDgaUpdateUrbanPlanningConditionException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update UrbanPlanningCondition" });

            //    hasChanges = reestrDbDgaUpdateUrbanPlanningConditionException is DbUpdateConcurrencyException;

            //    if (!(reestrDbDgaUpdateUrbanPlanningConditionException is DbUpdateConcurrencyException))
            //    {
            //        canEdit = false;
            //    }
            //}
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}

