using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    public class LandLogics
    {
        public LandLogics()
        {
            this.UrbanPlanningConditions = new HashSet<UrbanPlanningConditionsLogics>();
            this.ConstructionPassport = new HashSet<ConstructionPassportLogics>();
        }

        public int IdLand { get; set; }
        public string CadastralNumber { get; set; }
        public int? TargetLandId { get; set; }
        public int? PlotAssignmentId { get; set; }

        public virtual PlotAssignmentLogics PlotAssignment { get; set; }
        public virtual TargetLandLogics TargetLand { get; set; }
        public virtual ICollection<UrbanPlanningConditionsLogics> UrbanPlanningConditions { get; set; }
        public virtual ICollection<ConstructionPassportLogics> ConstructionPassport { get; set; }
    }
}
