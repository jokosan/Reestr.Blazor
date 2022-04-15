using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    public class SolutionLogics
    {
        public SolutionLogics()
        {
            this.Streets = new HashSet<StreetsLogics>();
        }

        public int IdSolution { get; set; }
        public int? DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string UrlSolution { get; set; }

        public virtual ICollection<StreetsLogics> Streets { get; set; }
    }
}
