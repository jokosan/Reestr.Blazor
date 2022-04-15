using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class AddressType
    {
        public AddressType()
        {
            this.Addressings = new HashSet<Addressing>();
        }

        [Key]
        public int IdAddressType { get; set; }
        public string NameAddressType { get; set; }

        public virtual ICollection<Addressing> Addressings { get; set; }
    }
}
