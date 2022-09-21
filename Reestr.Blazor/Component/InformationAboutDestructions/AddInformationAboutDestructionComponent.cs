using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Reestr.Blazor.Services;
using Reestr.Blazor.Pages.Security;
using Reestr.Logics.Service;
using Reestr.Database.Model;

namespace Reestr.Blazor.Component.InformationAboutDestructions
{
    public partial class AddInformationAboutDestructionComponent : ComponentBase
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
        protected InformationAboutDestructionServises ReestrDbDga { get; set; }

        [Parameter]
        public dynamic RegisterOfEmergencyBuildingsId { get; set; }

        InformationAboutDestruction _informationaboutdestruction;
        protected InformationAboutDestruction informationaboutdestruction
        {
            get
            {
                return _informationaboutdestruction;
            }
            set
            {
                if (!object.Equals(_informationaboutdestruction, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "informationaboutdestruction", NewValue = value, OldValue = _informationaboutdestruction };
                    _informationaboutdestruction = value;
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
            informationaboutdestruction = new InformationAboutDestruction() { };
        }

        protected async System.Threading.Tasks.Task Form0Submit(InformationAboutDestruction args)
        {
            informationaboutdestruction.RegisterOfEmergencyBuildingsId = int.Parse($"{RegisterOfEmergencyBuildingsId}");

            try
            {
                var reestrDbDgaCreateInformationAboutDestructionResult = await ReestrDbDga.CreateInformationAboutDestruction(informationaboutdestruction);
                DialogService.Close(informationaboutdestruction);
            }
            catch (System.Exception reestrDbDgaCreateInformationAboutDestructionException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new InformationAboutDestruction!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
