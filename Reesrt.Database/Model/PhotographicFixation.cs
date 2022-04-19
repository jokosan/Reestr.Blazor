using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class PhotographicFixation
    {
        public int IdPhotographicFixation { get; set; }
        public int? RegisterOfEmergencyBuildingsId { get; set; }
        public string Url { get; set; }

        public virtual RegisterOfEmergencyBuildings RegisterOfEmergencyBuildings { get; set; }
    }
}
