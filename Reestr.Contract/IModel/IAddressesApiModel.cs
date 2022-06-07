using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Contract.IModel
{
    public interface IAddressesApiModel
    {
        string block { get; set; }
        string detail { get; set; }
        string detail_number { get; set; }
        string detail_ua { get; set; }
        string district_ua { get; set; }
        int id { get; set; }
        decimal lat { get; set; }
        decimal longi { get; set; }
        string name_ukr { get; set; }
        string number { get; set; }
        int postcode { get; set; }
        string same_addr_comm { get; set; }
        string suffix { get; set; }
        string type_ukr { get; set; }
    }
}
