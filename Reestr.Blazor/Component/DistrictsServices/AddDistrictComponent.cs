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
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.Repositories;
using Reestr.Logics.Contract.ServiceContract;
using Reestr.Logics.Service;

namespace Reestr.Blazor.Component.DistrictsServices
{
    public class AddDistrictComponent : ComponentBase
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
        protected DbRepository<Districts> ReestrDb { get; set; }

        [Inject]
        private DistrictsServises _districts { get; set; }

        Districts _district;
        protected Districts district
        {
            get
            {
                return _district;
            }
            set
            {
                if (!object.Equals(_district, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "district", NewValue = value, OldValue = _district };
                    _district = value;
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
            district = new Districts() { };
        }

        protected async System.Threading.Tasks.Task Form0Submit(Districts args)
        {
            try
            {
                var reestrDbCreateDistrictResult = await _districts.CreateDistrict(args);
                DialogService.Close(district);
            }
            catch (System.Exception reestrDbCreateDistrictException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new District!" });
            }
        }

        protected async Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}

