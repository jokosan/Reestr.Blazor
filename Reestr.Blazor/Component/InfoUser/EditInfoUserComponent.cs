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
using Reestr.Database.Context;
using Reestr.Blazor.Services;
using Reestr.Logics.Infrastructure.UnitOfWorks;

namespace Reestr.Blazor.Component.InfoUser
{
    public class EditInfoUserComponent : ComponentBase
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

        [Parameter]
        public dynamic IdInfoUser { get; set; }

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

        Database.Model.InfoUser _infouser;
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
            hasChanges = false;

            canEdit = true;

            var reestrGetInfoUserByIdInfoUserResult = await unitOfWork.InfoUserUnitOfWork.GetById(IdInfoUser);
            infouser = reestrGetInfoUserByIdInfoUserResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        //protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        //{
        //    Reestr.Reset();

        //    await this.Load();
        //}

        protected async System.Threading.Tasks.Task Form0Submit(Database.Model.InfoUser args)
        {
            try
            {
                unitOfWork.InfoUserUnitOfWork.Update(IdInfoUser, infouser);
                await unitOfWork.Save();
            }
            catch (System.Exception reestrUpdateInfoUserException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update InfoUser" });

                hasChanges = reestrUpdateInfoUserException is DbUpdateConcurrencyException;

                if (!(reestrUpdateInfoUserException is DbUpdateConcurrencyException))
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
