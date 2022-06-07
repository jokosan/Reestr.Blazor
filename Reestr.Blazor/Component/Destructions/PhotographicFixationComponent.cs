using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Logics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reestr.Blazor.Component.Destructions
{
    public class PhotographicFixationComponent : ComponentBase
    {
        [Inject]
        protected PhotographicFixationServises PhotographicFixationServices { get; set; }

        [Inject]
        protected UnitOfWork UnitOfWork { get; set; } 

        [Parameter]
        public dynamic Id { get; set; }

        public IEnumerable<Reestr.Database.Model.PhotographicFixation> photographicFixations { get; set; }
        public RegisterOfEmergencyBuildings registerOfEmergencyBuildings { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await PhotographicFixationServices.GetById(Convert.ToInt32(Id));
            photographicFixations = result;
        }
    }
}
 