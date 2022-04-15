using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    // Назначение участка
    public class PlotAssignmentLogics
    {
        public PlotAssignmentLogics()
        {
            this.Lands = new HashSet<LandLogics>();
        }

        public int IdPlotAssignment { get; set; }
        public string Name { get; set; }

         public virtual ICollection<LandLogics> Lands { get; set; }
    }
}
