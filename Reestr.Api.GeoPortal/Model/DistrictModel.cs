using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Model
{
    public class DistrictModel
    {
        public int id { get; set; }
        public string name_ru { get; set; }
        public string name_ukr { get; set; }
        public string name_ru_before { get; set; }
        public string name_ukr_before { get; set; }
    }
}
