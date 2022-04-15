using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class Postcode
    {
        public Postcode()
        {
            this.Addressings = new HashSet<Addressing>();
        }

        public int IdPostcode { get; set; }
        public int? Csode { get; set; }

        public virtual ICollection<Addressing> Addressings { get; set; }
    }
}
