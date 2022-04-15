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

namespace Reestr.Blazor.Component.Addressings
{
    public class EditAddressingComponent : ComponentBase
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

        [Parameter]
        public dynamic IdAddressing { get; set; }

       Addressing _addressing;
        
        protected Addressing addressing
        {
            get
            {
                return _addressing;
            }
            set
            {
                if (!object.Equals(_addressing, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "addressing", NewValue = value, OldValue = _addressing };
                    _addressing = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        //#region 
        //public int streetCategoriesId;

        //#endregion

        //public IEnumerable<StreetCategory> _getStreetCategoriesResult;

        //protected IEnumerable<StreetCategory> getStreetCategoriesResult
        //{
        //    get
        //    {
        //        return _getStreetCategoriesResult;
        //    }
        //    set
        //    {
        //        if (!object.Equals(_getStreetsResult, value))
        //        {
        //            var args = new PropertyChangedEventArgs() { Name = "getStreetCategoriesResult", NewValue = value, OldValue = _getStreetCategoriesResult };
        //            _getStreetCategoriesResult = value;
        //            OnPropertyChanged(args);
        //            Reload();
        //        }
        //    }
        //}

        IEnumerable<Streets> _getStreetsResult;

        protected IEnumerable<Streets> getStreetsResult
        {
            get
            {
                return _getStreetsResult;
            }
            set
            {
                if (!object.Equals(_getStreetsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStreetsResult", NewValue = value, OldValue = _getStreetsResult };
                    _getStreetsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Districts> _getDistrictsResult;

        protected IEnumerable<Districts> getDistrictsResult
        {
            get
            {
                return _getDistrictsResult;
            }
            set
            {
                if (!object.Equals(_getDistrictsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDistrictsResult", NewValue = value, OldValue = _getDistrictsResult };
                    _getDistrictsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Postcode> _getPostcodesResult;

        protected IEnumerable<Postcode> getPostcodesResult
        {
            get
            {
                return _getPostcodesResult;
            }
            set
            {
                if (!object.Equals(_getPostcodesResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPostcodesResult", NewValue = value, OldValue = _getPostcodesResult };
                    _getPostcodesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<AddressType> _getAddressTypesResult;
        protected IEnumerable<AddressType> getAddressTypesResult
        {
            get
            {
                return _getAddressTypesResult;
            }
            set
            {
                if (!object.Equals(_getAddressTypesResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getAddressTypesResult", NewValue = value, OldValue = _getAddressTypesResult };
                    _getAddressTypesResult = value;
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
            var reestrDbGetAddressingByIdAddressingResult = await AddressingS.GetAddressingByIdAddressing(IdAddressing);
            addressing = reestrDbGetAddressingByIdAddressingResult;

            var reestrDbGetStreetsResult = await ReestrDb.StreetsUnitOfWork.GetInclude("StreetCategory");
            getStreetsResult = reestrDbGetStreetsResult;

            var reestrDbGetDistrictsResult = await ReestrDb.DistrictsUnitOfWork.Get();
            getDistrictsResult = reestrDbGetDistrictsResult;

            var reestrDbGetPostcodesResult = await ReestrDb.PostcodeUnitOfWork.Get();
            getPostcodesResult = reestrDbGetPostcodesResult;

            var reestrDbGetAddressTypesResult = await ReestrDb.AddressTypeUnitOfWork.Get();
            getAddressTypesResult = reestrDbGetAddressTypesResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(Addressing args)
        {
            try
            {
                var reestrDbUpdateAddressingResult = await AddressingS.UpdateAddressing(IdAddressing, addressing);
                DialogService.Close(addressing);
            }
            catch (System.Exception reestrDbUpdateAddressingException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update Addressing" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
