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
        protected PhotographicFixationServices PhotographicFixationServices { get; set; }

        [Inject]
        protected UnitOfWork UnitOfWork { get; set; } 

        [Parameter]
        public dynamic Id { get; set; }

        public IEnumerable<Reestr.Database.Model.PhotographicFixation> photographicFixations { get; set; }
        public RegisterOfEmergencyBuildings registerOfEmergencyBuildings { get; set; }
        public Streets Streets { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await PhotographicFixationServices.GetById(Convert.ToInt32(Id));
            photographicFixations = result;

            //var resultRegisterOfEmergencyBuildings = await UnitOfWork.RegisterOfEmergencyBuildingsUnitOfWork.GetById(Convert.ToInt32(Id));
            //registerOfEmergencyBuildings = resultRegisterOfEmergencyBuildings;

            //var resultStreets = await UnitOfWork.StreetsUnitOfWork.FirstOrDefaultAsyncInclude(x => x.IdStreets == registerOfEmergencyBuildings.Addressing.StreetsId, "StreetCategory");
            //Streets = resultStreets;
        }
    }
}
 