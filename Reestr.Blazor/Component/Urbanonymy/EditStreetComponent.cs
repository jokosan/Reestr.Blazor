using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.EntityFrameworkCore;
using Reestr.Blazor.Services;
using Reestr.Logics.Infrastructure.Repositories;
using Reestr.Database.Model;
using Reestr.Blazor.Pages;
using Reestr.Blazor.Pages.District;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Logics.Service;

namespace Reestr.Blazor.Component.Urbanonymy
{
    public class EditStreetComponent : ComponentBase
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
        private StreetsService _streetsService { get; set; }

        [Parameter]
        public dynamic IdStreets { get; set; }

        Streets _street;
        protected Streets street
        {
            get
            {
                return _street;
            }
            set
            {
                if (!object.Equals(_street, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "street", NewValue = value, OldValue = _street };
                    _street = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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
            var reestrDbGetStreetByIdStreetsResult = await _streetsService.GetStreetByIdStreets(IdStreets);
            street = reestrDbGetStreetByIdStreetsResult;

            var reestrDbGetStreetCategoriesResult = await ReestrDb.StreetCategoryUnitOfWork.Get();
            getStreetCategoriesResult = reestrDbGetStreetCategoriesResult;

            var reestrDbGetSolutionsResult = await ReestrDb.SolutionUnitOfWork.Get();
            getSolutionsResult = reestrDbGetSolutionsResult;
        }

        protected async Task Form0Submit(Streets args)
        {
            try
            {
                var reestrDbUpdateStreetResult = await _streetsService.UpdateStreet(IdStreets, street);
                DialogService.Close(street);
            }
            catch (System.Exception reestrDbUpdateStreetException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update Street" });
            }
        }

        protected async Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
