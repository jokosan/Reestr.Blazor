using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class BuildingType
    {
        public BuildingType()
        {
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildings>();
        }

        public int IdBuildingType { get; set; }
        public string NameBuildingType { get; set; }

        public virtual ICollection<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
    }
}
