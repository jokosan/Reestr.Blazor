using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class Solution
    {
        public Solution()
        {
            this.Streets = new HashSet<Streets>();
        }

        public int IdSolution { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string UrlSolution { get; set; }

        public virtual ICollection<Streets> Streets { get; set; }
    }
}
