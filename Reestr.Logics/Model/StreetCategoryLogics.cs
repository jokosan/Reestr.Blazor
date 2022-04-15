using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    // Категория_улиц

    public class StreetCategoryLogics
    {
        public StreetCategoryLogics()
        {
            this.Streets = new HashSet<StreetsLogics>();
        }

        public int IdStreetCategory { get; set; }
        public string NameCategoryRu { get; set; }
        public string NameCategoryUa { get; set; }

        public virtual ICollection<StreetsLogics> Streets { get; set; }
    }
}
