using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    public class StreetsLogics
    {
        public StreetsLogics()
        {
            this.Addressings = new HashSet<AddressingLogics>();
        }

        public int IdStreets { get; set; }
        public int? StreetCategoryId { get; set; }
        public int? StreetArchivesId { get; set; }
        public int? SolutionId { get; set; }
        public int? StreetsMapId { get; set; }
        public string NameStreetsRu { get; set; }
        public string NameStreetsUa { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<AddressingLogics> Addressings { get; set; }
        public virtual StreetCategoryLogics StreetCategory { get; set; }
        public virtual SolutionLogics Solution { get; set; }
    }
}
