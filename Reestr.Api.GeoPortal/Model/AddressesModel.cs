using Reestr.Api.GeoPortal.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Model
{
    public class AddressesModel 
    {
        public int id { get; set; }
        public decimal lat { get; set; }
        public decimal longi { get; set; }
        public string name_ru { get; set; }
        public string name_ukr { get; set; }
        public string number { get; set; }
        public int postcode { get; set; }
        public string reg_date { get; set; }
        public string same_addr_comm { get; set; }
        public int streetid { get; set; }
        public string suffix { get; set; }
        public string type_ru { get; set; }
        public string type_ukr { get; set; }
        public string valid { get; set; }
        public string block { get; set; }
        public string detail { get; set; }
        public string detail_number { get; set; }
        public string detail_ua { get; set; }
        public int districtId { get; set; }
        public string district_ru { get; set; }
        public string district_ua { get; set; }
        public List<int> documents { get; set; }

    }
}
