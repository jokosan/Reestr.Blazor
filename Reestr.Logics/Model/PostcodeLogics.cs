using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    public class PostcodeLogics
    {
        public PostcodeLogics()
        {
            this.Addressings = new HashSet<AddressingLogics>();
        }

        public int IdPostcode { get; set; }
        public int? Csode { get; set; }

        public virtual ICollection<AddressingLogics> Addressings { get; set; }
    }
}
