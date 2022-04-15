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
using Reestr.Blazor.Pages.StreetsCategory;

namespace Reestr.Blazor.Component.StreetsCategory
{
    public class StreetCategoriesComponent : ComponentBase
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

        protected RadzenDataGrid<StreetCategory> grid0;

        IEnumerable<StreetCategory> _getStreetCategoriesResult;

        protected IEnumerable<StreetCategory> getStreetCategoriesResult
        {
            get
            {
                return _getStreetCategoriesResult;
            }
            set
            {
                if (!object.Equals(_getStreetCategoriesResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStreetCategoriesResult", NewValue = value, OldValue = _getStreetCategoriesResult };
                    _getStreetCategoriesResult = value;
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
            var reestrDbGetStreetCategoriesResult = await ReestrDb.StreetCategoryUnitOfWork.Get();
            getStreetCategoriesResult = reestrDbGetStreetCategoriesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddStreetCategory>("Add Street Category", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

       
        protected async System.Threading.Tasks.Task Grid0RowSelect(StreetCategory args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStreetCategory>("Edit Street Category", new Dictionary<string, object>() { { "IdStreetCategory", args.IdStreetCategory } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDeleteStreetCategoryResult = await ReestrDb.DeleteStreetCategory(data.IdStreetCategory);
            //        if (reestrDbDeleteStreetCategoryResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDeleteStreetCategoryException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete StreetCategory" });
            //}
        }
    }
}
