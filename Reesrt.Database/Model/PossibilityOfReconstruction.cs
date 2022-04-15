using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class PossibilityOfReconstruction
    {
        public PossibilityOfReconstruction()
        {
            this.RegisterOfEmergencyBuildings = new HashSet<RegisterOfEmergencyBuildings>();
        }

        public int IdPossibilityOfReconstruction { get; set; }
        public bool Status { get; set; }
        public string ScanDoc { get; set; }        

        public virtual ICollection<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
    }
}
