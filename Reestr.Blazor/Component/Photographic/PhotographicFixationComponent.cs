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
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Logics.Service;
using Reestr.Database.Model;
using Reestr.Logics.Modul.GoeJson;

namespace Reestr.Blazor.Component.Photographic
{
    public class PhotographicFixationComponent : ComponentBase
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

        protected string addressingApi = $"http://localhost:5000/";

        [Inject]
        protected PhotographicFixationServises PhotographicFixationServises { get; set; }

        protected RadzenDataGrid<Database.Model.PhotographicFixation> grid0;

        IEnumerable<Database.Model.PhotographicFixation> _getPhotographicFixationsResult;
        protected IEnumerable<Database.Model.PhotographicFixation> getPhotographicFixationsResult
        {
            get
            {
                return _getPhotographicFixationsResult;
            }
            set
            {
                if (!object.Equals(_getPhotographicFixationsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPhotographicFixationsResult", NewValue = value, OldValue = _getPhotographicFixationsResult };
                    _getPhotographicFixationsResult = value;
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
            var reestrDbDgaGetPhotographicFixationsResult = await PhotographicFixationServises.GetPhotographicFixations(new Query() { Expand = "RegisterOfEmergencyBuildings,RegisterOfEmergencyBuildings.AddressingApi" });

            getPhotographicFixationsResult = reestrDbDgaGetPhotographicFixationsResult;
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Дійсно видалити цей запис?") == true)
                {
                    var reestrDbDgaDeletePhotographicFixationResult = await PhotographicFixationServises.DeletePhotographicFixation(data.IdPhotographicFixation);
                    if (reestrDbDgaDeletePhotographicFixationResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception reestrDbDgaDeletePhotographicFixationException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete PhotographicFixation" });
            }
        }
    }
}
