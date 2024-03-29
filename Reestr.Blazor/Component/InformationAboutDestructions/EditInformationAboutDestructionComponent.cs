﻿using System;
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
using Reestr.Database.Model;
using Reestr.Logics.Service;

namespace Reestr.Blazor.Component.InformationAboutDestructions
{
    public partial class EditInformationAboutDestructionComponent : ComponentBase
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
        public dynamic IdInformationAboutDestruction { get; set; }

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
            hasChanges = false;

            canEdit = true;

            var reestrDbDgaGetInformationAboutDestructionByIdInformationAboutDestructionResult = await ReestrDbDga.GetInformationAboutDestructionByIdInformationAboutDestruction(IdInformationAboutDestruction);
            informationaboutdestruction = reestrDbDgaGetInformationAboutDestructionByIdInformationAboutDestructionResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            ReestrDbDga.Reset();

            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(InformationAboutDestruction args)
        {
            try
            {
                var reestrDbDgaUpdateInformationAboutDestructionResult = await ReestrDbDga.UpdateInformationAboutDestruction(IdInformationAboutDestruction, informationaboutdestruction);
                DialogService.Close(informationaboutdestruction);
            }
            catch (System.Exception reestrDbDgaUpdateInformationAboutDestructionException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update InformationAboutDestruction" });

                hasChanges = reestrDbDgaUpdateInformationAboutDestructionException is DbUpdateConcurrencyException;

                if (!(reestrDbDgaUpdateInformationAboutDestructionException is DbUpdateConcurrencyException))
                {
                    canEdit = false;
                }
            }
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
