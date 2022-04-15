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

namespace Reestr.Blazor.Component.StreetsCategory
{
    public class EditStreetCategoriesComponent : ComponentBase
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

        [Parameter]
        public dynamic IdStreetCategory { get; set; }

        [Inject]
        protected StreetCategoriesServises ScServise { get; set; }


        StreetCategory _streetcategory;
        
        protected StreetCategory streetcategory
        {
            get
            {
                return _streetcategory;
            }
            set
            {
                if (!object.Equals(_streetcategory, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "streetcategory", NewValue = value, OldValue = _streetcategory };
                    _streetcategory = value;
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
            var reestrDbGetStreetCategoryByIdStreetCategoryResult = await ScServise.GetStreetCategoryByIdStreetCategory(IdStreetCategory);
            streetcategory = reestrDbGetStreetCategoryByIdStreetCategoryResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(StreetCategory args)
        {
            try
            {
                var reestrDbUpdateStreetCategoryResult = await ScServise.UpdateStreetCategory(IdStreetCategory, streetcategory);
                DialogService.Close(streetcategory);
            }
            catch (System.Exception reestrDbUpdateStreetCategoryException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update StreetCategory" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
