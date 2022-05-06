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
using Reestr.Blazor.Pages.Addressing;

namespace Reestr.Blazor.Component.Addressings
{
    public class DataAddressingComponent : ComponentBase
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
        protected AddressingServices AddressingS { get; set; }

        protected RadzenDataGrid<Addressing> grid0;

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

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        protected async Task Load()
        {
            var reestrDbGetAddressingsResult = await AddressingS.GetAddressings(new Query() { Expand = "Districts,Postcode,AddressType,Streets.StreetCategory" });
            getAddressingsResult = reestrDbGetAddressingsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddAddressing>("Add Addressing", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

     
        protected async System.Threading.Tasks.Task Grid0RowSelect(Addressing args)
        {
            var dialogResult = await DialogService.OpenAsync<EditAddressing>("Edit Addressing", new Dictionary<string, object>() { { "IdAddressing", args.IdAddressing } });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDbDeleteAddressingResult = await ReestrDb.DeleteAddressing(data.IdAddressing);
            //        if (reestrDbDeleteAddressingResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDbDeleteAddressingException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete Addressing" });
            //}
        }
    }
}
