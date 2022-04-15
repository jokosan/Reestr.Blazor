using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class TypeOfOwnership
    {
        public TypeOfOwnership()
        {
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildings>();
        }

        public int IdTypeOfOwnership { get; set; }
        public string NameTypeOfOwnership { get; set; }

        public virtual ICollection<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
    }
}
