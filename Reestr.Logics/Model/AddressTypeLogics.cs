using Reestr.Logics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    public class AddressTypeLogics
    {
        public AddressTypeLogics()
        {
            this.Addressings = new HashSet<AddressingLogics>();
        }

        [Key]
        public int IdAddressType { get; set; }
        public string NameAddressType { get; set; }

        public virtual ICollection<AddressingLogics> Addressings { get; set; }
    }
}
