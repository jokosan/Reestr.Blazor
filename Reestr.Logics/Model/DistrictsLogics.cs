using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    public class DistrictsLogics
    {
        public DistrictsLogics()
        {
            this.Addressings = new HashSet<AddressingLogics>();
        }

        public int IdDistricts { get; set; }
        public string NameDistricts { get; set; }

        public virtual ICollection<AddressingLogics> Addressings { get; set; }
    }
}
