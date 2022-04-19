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

namespace Reestr.Blazor.Component.Solutions
{
    public class SolutionComponent : ComponentBase
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

        protected RadzenDataGrid<Solution> grid0;

        IEnumerable<Solution> _getSolutionsResult;
        protected IEnumerable<Solution> getSolutionsResult
        {
            get
            {
                return _getSolutionsResult;
            }
            set
            {
                if (!object.Equals(_getSolutionsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getSolutionsResult", NewValue = value, OldValue = _getSolutionsResult };
                    _getSolutionsResult = value;
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
            var reestrDbGetSolutionsResult = await ReestrDb.SolutionUnitOfWork.Get();
            getSolutionsResult = reestrDbGetSolutionsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSolution>("Add Solution", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(DataGridRowMouseEventArgs<Solution> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSolution>("Edit Solution", new Dictionary<string, object>() { { "IdSolution", args.Data.IdSolution } });
            await grid0.Reload();
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDeleteSolutionResult = await ReestrDb.DeleteSolution(data.IdSolution);
            //        if (reestrDbDeleteSolutionResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDeleteSolutionException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete Solution" });
            //}
        }
    }
}
