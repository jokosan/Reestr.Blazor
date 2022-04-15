using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    // Адресация
    public class AddressingLogics
    {
        public AddressingLogics()
        {
            this.UrbanPlanningConditions = new HashSet<UrbanPlanningConditionsLogics>();
            this.ProjectArchive = new HashSet<ProjectArchiveLogics>();
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildingsLogics>();
            this.ConstructionPassport = new HashSet<ConstructionPassportLogics>();
        }

        public int IdAddressing { get; set; }
        public int? StreetsId { get; set; }
        public int? DistrictsId { get; set; }
        public string Number { get; set; }
        public string Frame { get; set; }
        public string Letter { get; set; }
        public int? PostcodeId { get; set; }
        public int? AddressTypeId { get; set; }

        public virtual PostcodeLogics Postcode { get; set; }
        public virtual DistrictsLogics Districts { get; set; }
        public virtual StreetsLogics Streets { get; set; }
        public virtual AddressTypeLogics AddressType { get; set; } 

        public virtual ICollection<UrbanPlanningConditionsLogics> UrbanPlanningConditions { get; set; }
        public virtual ICollection<ProjectArchiveLogics> ProjectArchive { get; set; }
        public virtual ICollection<RegisterOfEmergencyBuildingsLogics> RegisterOfEmergencyBuildings { get; set; }
        public virtual ICollection<ConstructionPassportLogics> ConstructionPassport { get; set; }
    }
}
