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
using Reestr.Database.Context;
using Reestr.Logics.Infrastructure.UnitOfWorks;

namespace Reestr.Blazor.Component.InfoUser
{
    public class AddInfoUserComponent : ComponentBase
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
        protected UnitOfWork unitOfWork { get; set; }

        Database.Model.InfoUser _infouser;

        protected bool popup;
        protected Database.Model.InfoUser infouser
        {
            get
            {
                return _infouser;
            }
            set
            {
                if (!object.Equals(_infouser, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "infouser", NewValue = value, OldValue = _infouser };
                    _infouser = value;
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
            infouser = new Database.Model.InfoUser() { };
        }

        protected async System.Threading.Tasks.Task Form0Submit(Database.Model.InfoUser args)
        {
            try
            {
                infouser.DateOfRegistration = DateTime.Now;
                unitOfWork.InfoUserUnitOfWork.Insert(infouser);
                await unitOfWork.Save();
                NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Інформація", Detail = "Вашу заявку буде розглянуто найближчим часом", Duration = 10000 });

            }
            catch (System.Exception reestrCreateInfoUserException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new InfoUser!" });
            }

            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
