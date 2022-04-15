using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // Целевое земельного участка
    public class TargetLand
    {
        public TargetLand()
        {
            this.Lands = new HashSet<Land>();
        }

        public int IdTargetLand { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Land> Lands { get; set; }
    }
}
