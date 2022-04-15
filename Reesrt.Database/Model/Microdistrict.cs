using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class Microdistrict
    {
        public Microdistrict()
        {
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildings>();
        }

        public int IdMicrodistrict { get; set; }
        public string NameMicrodistrict { get; set; }
        public string Note { get; set; }

        public virtual ICollection<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
    }
}
