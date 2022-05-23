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
using Reestr.Blazor.Pages.InfoUser;
using Reestr.Logics.Infrastructure.UnitOfWorks;

namespace Reestr.Blazor.Component.InfoUser
{
    public class InfoUserComponent : ComponentBase
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
        protected RadzenDataGrid<Database.Model.InfoUser> grid0;

        IEnumerable<Database.Model.InfoUser> _getInfoUsersResult;
        protected IEnumerable<Database.Model.InfoUser> getInfoUsersResult
        {
            get
            {
                return _getInfoUsersResult;
            }
            set
            {
                if (!object.Equals(_getInfoUsersResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getInfoUsersResult", NewValue = value, OldValue = _getInfoUsersResult };
                    _getInfoUsersResult = value;
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
            var reestrGetInfoUsersResult = await unitOfWork.InfoUserUnitOfWork.Get();
            getInfoUsersResult = reestrGetInfoUsersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInfoUser>("Реєстрація користувача", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Database.Model.InfoUser args)
        {
            var dialogResult = await DialogService.OpenAsync<EditInfoUser>("Edit Info User", new Dictionary<string, object>() { { "IdInfoUser", args.IdInfoUser } });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var reestrDeleteInfoUserResult = await Reestr.DeleteInfoUser(data.IdInfoUser);
            //        if (reestrDeleteInfoUserResult != null)
            //        {
            //            await grid0.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception reestrDeleteInfoUserException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete InfoUser" });
            //}
        }
    }
}
