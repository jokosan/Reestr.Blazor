using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Reestr.Blazor.Services;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Database.Model;
using Reestr.Logics.Service;
using Reestr.Logics.Modul.Upload;

namespace Reestr.Blazor.Component.Solutions
{
    public class AddSolutionComponent : ComponentBase
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
        protected SolutionServises SolutionServise { get; set; }

        Solution _solution;

        protected Solution solution
        {
            get
            {
                return _solution;
            }
            set
            {
                if (!object.Equals(_solution, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "solution", NewValue = value, OldValue = _solution };
                    _solution = value;
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
            solution = new Solution() { };
        }

        protected async System.Threading.Tasks.Task Form0Submit(Solution args)
        {
            try
            {
                args.UrlSolution = UploadSaveModel.UploadList.FirstOrDefault();
                UploadSaveModel.UploadList.Clear();

                var reestrDbCreateSolutionResult = await SolutionServise.CreateSolution(solution);
                DialogService.Close(solution);
            }
            catch (System.Exception reestrDbCreateSolutionException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new Solution!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected int progress;
        protected string info;

        protected void OnProgress(UploadProgressArgs args, string name)
        {
            this.info = $"% '{name}' / Loaded: {args.Loaded}, Total: {args.Total} b, File: {args.Files.Single()}, Progress: {args.Progress}";
            this.progress = args.Progress;
        }
    }
}
