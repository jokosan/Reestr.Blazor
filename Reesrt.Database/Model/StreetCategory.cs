using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // Категория_улиц

    public class StreetCategory
    {       
        public int IdStreetCategory { get; set; }
        public string NameCategoryRu { get; set; }
        public string NameCategoryUa { get; set; }
        public string FullNameCategoryRu { get; set; }
        public string FullNameCategoryUa { get; set; }
    }
}
