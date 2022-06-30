using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.ModelApi
{
    public  class RegisterOfEmergencyBuildingsApiModel
    {
        public int IdRegisterOfEmergencyBuildings { get; set; }
        public int IdApiBuildings { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Longi { get; set; }
    }
}
