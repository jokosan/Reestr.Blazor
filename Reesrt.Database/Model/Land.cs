using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class Land
    {
        public Land()
        {
            this.UrbanPlanningConditions = new HashSet<UrbanPlanningConditions>();
            this.ConstructionPassport = new HashSet<ConstructionPassport>();
        }

        public int IdLand { get; set; }
        public string CadastralNumber { get; set; }
        public int? TargetLandId { get; set; }
        public int? PlotAssignmentId { get; set; }

        public virtual PlotAssignment PlotAssignment { get; set; }
        public virtual TargetLand TargetLand { get; set; }
        public virtual ICollection<UrbanPlanningConditions> UrbanPlanningConditions { get; set; }
        public virtual ICollection<ConstructionPassport> ConstructionPassport { get; set; }
    }
}
