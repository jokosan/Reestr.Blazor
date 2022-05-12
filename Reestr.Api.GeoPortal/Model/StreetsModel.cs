using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Api.GeoPortal.Model
{
    public class StreetsModel
    {
        public int id { get; set; }
        public int? street_type_id { get; set; }
        public string name_ru { get; set; }
        public string name_ukr { get; set; }
        public string reg_date { get; set; }
        public string type_ru { get; set; }
        public string type_ukr { get; set; }
        public double left_bottom_latitude { get; set; }
        public double left_bottom_longitude { get; set; }
        public double right_top_latitude { get; set; }
        public double right_top_longitude { get; set; }
        public string valid { get; set; }
        public int? before { get; set; }
        public int? before_too { get; set; }
        public int[] documents { get; set; }
    }
}
