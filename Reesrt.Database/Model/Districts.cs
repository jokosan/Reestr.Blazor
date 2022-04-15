using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class Districts
    {
        public Districts()
        {
            this.Addressings = new HashSet<Addressing>();
        }

        public int IdDistricts { get; set; }
        public string NameDistricts { get; set; }

        public virtual ICollection<Addressing> Addressings { get; set; }
    }
}
