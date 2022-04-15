using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // Назначение участка
    public class PlotAssignment
    {
        public PlotAssignment()
        {
            this.Lands = new HashSet<Land>();
        }

        public int IdPlotAssignment { get; set; }
        public string Name { get; set; }

         public virtual ICollection<Land> Lands { get; set; }
    }
}
