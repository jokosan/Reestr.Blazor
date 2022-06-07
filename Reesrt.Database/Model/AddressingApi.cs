using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class AddressingApi
    {
        public AddressingApi()
        {
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildings>();
        }

        public int IdApiBuildings { get; set; }
        public int IdAddressingApi { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Longi { get; set; }
        public string NameUkr { get; set; }
        public string Number { get; set; }
        public int? Postcode { get; set; }
        public DateTime? RegDate { get; set; }
        public string SameAddrComm { get; set; }
        public int? Streetid { get; set; }
        public string Suffix { get; set; }
        public string TypeUkr { get; set; }
        public bool Valid { get; set; }
        public string Block { get; set; }
        public string Detail { get; set; }
        public string DetailNumber { get; set; }
        public string DetailUa { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictUa { get; set; }

        public virtual ICollection<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
    }
}
