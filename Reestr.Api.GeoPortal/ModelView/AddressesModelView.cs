using Reestr.Api.GeoPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.ModelView
{
    public class AddressesModelView
    {
        public int IdRegisterOfEmergencyBuildings { get; set; }
        public string MicrodistrictName { get; set; }
        public string SectorNumber { get; set; }
        public string BuildingTypeName { get; set; }
        public string TypeOfOwnershipName { get; set; }

        public string AddressingName { get; set; }    
        public string TypeOfDestruction { get; set; } 
        public string TypeBuildings { get; set; } 
        public string Description { get; set; } 
        public string JobDescription { get; set; }
        public bool? PhotographicFixation { get; set; } 
        public int? PossibilityOfReconstructionId { get; set; } 
        public string Note { get; set; } 

        public int? AddressesApiId { get; set; }

        public int? id { get; set; }
        public decimal? lat { get; set; }
        public decimal? longi { get; set; }
        public string name_ukr { get; set; }
        public string number { get; set; }
        public int? postcode { get; set; }      
        public int? streetid { get; set; }
        public string type_ukr { get; set; }
        public int? districtId { get; set; }
        public string district_ua { get; set; }

        public virtual AddressesModel Addressing { get; set; }
    }
}
