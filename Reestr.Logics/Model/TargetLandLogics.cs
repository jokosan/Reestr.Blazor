using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    // Целевое земельного участка
    public class TargetLandLogics
    {
        public TargetLandLogics()
        {
            this.Lands = new HashSet<LandLogics>();
        }

        public int IdTargetLand { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LandLogics> Lands { get; set; }
    }
}
