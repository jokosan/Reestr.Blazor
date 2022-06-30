using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class DocumentStatus
    {
        public DocumentStatus()
        {
            this.UrbanPlanningConditions = new HashSet<UrbanPlanningConditions>();
        }

        public int IdDocumentStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UrbanPlanningConditions> UrbanPlanningConditions { get; set; }

    }
}
