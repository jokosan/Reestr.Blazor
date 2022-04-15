using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class Streets
    {
        public Streets()
        {
            this.Addressings = new HashSet<Addressing>();
        }

        public int IdStreets { get; set; }
        public int? StreetCategoryId { get; set; }
        public int? SolutionId { get; set; }
        public int? StreetsMapId { get; set; }
        public string NameStreetsRu { get; set; } 
        public string NameStreetsUa { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Addressing> Addressings { get; set; }
        public virtual StreetCategory StreetCategory { get; set; }
        public virtual Solution Solution { get; set; }
    }
}
