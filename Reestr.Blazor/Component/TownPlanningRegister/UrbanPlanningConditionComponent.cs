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
using Reestr.Blazor.Pages.TownPlanningRegister;

namespace Reestr.Blazor.Component.TownPlanningRegister
{
    public class UrbanPlanningConditionComponent : ComponentBase
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

        protected RadzenDataGrid<UrbanPlanningConditions> grid0;

        [Inject]
        protected UrbanPlanningConditionServises urbanPlanningConditionServises { get; set; }

        IEnumerable<UrbanPlanningConditions> _getUrbanPlanningConditionsResult;
        protected IEnumerable<UrbanPlanningConditions> getUrbanPlanningConditionsResult
        {
            get
            {
                return _getUrbanPlanningConditionsResult;
            }
            set
            {
                if (!object.Equals(_getUrbanPlanningConditionsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getUrbanPlanningConditionsResult", NewValue = value, OldValue = _getUrbanPlanningConditionsResult };
                    _getUrbanPlanningConditionsResult = value;
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
            var reestrDbDgaGetUrbanPlanningConditionsResult = await urbanPlanningConditionServises.GetUrbanPlanningConditions(new Query() { Expand = "Land,DocumentStatus,TypeOfConstruction" });
            getUrbanPlanningConditionsResult = reestrDbDgaGetUrbanPlanningConditionsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddUrbanPlanningCondition>("Add Urban Planning Condition", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(UrbanPlanningConditions args)
        {
            var dialogResult = await DialogService.OpenAsync<EditUrbanPlanningCondition>("Edit Urban Planning Condition", new Dictionary<string, object>() { { "IdUrbanPlanningConditions", args.IdUrbanPlanningConditions } });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDgaDeleteUrbanPlanningConditionResult = await ReestrDbDga.DeleteUrbanPlanningCondition(int.Parse($"{data.IdUrbanPlanningConditions}"));
            //        if (reestrDbDgaDeleteUrbanPlanningConditionResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDgaDeleteUrbanPlanningConditionException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete UrbanPlanningCondition" });
            //}
        }
    }
}
