using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // Адресация
    public class Addressing
    {
        public Addressing()
        {
            this.UrbanPlanningConditions = new HashSet<UrbanPlanningConditions>();
            this.ProjectArchive = new HashSet<ProjectArchive>();
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildings>();
            this.ConstructionPassport = new HashSet<ConstructionPassport>();
        }

        public int IdAddressing { get; set; }
        public int? StreetsId { get; set; }
        public int? DistrictsId { get; set; }
        public int? AddressingMapId { get; set; }
        public string Number { get; set; }
        public string Frame { get; set; }
        public int? Floor { get; set; }
        public string Letter { get; set; }      
        public int? PostcodeId { get; set; }
        public int? AddressTypeId { get; set; }

        public virtual Postcode Postcode { get; set; }
        public virtual Districts Districts { get; set; }
        public virtual Streets Streets { get; set; }
        public virtual AddressType AddressType { get; set; } 

        public virtual ICollection<UrbanPlanningConditions> UrbanPlanningConditions { get; set; }
        public virtual ICollection<ProjectArchive> ProjectArchive { get; set; }
        public virtual ICollection<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
        public virtual ICollection<ConstructionPassport> ConstructionPassport { get; set; }
    }
}
