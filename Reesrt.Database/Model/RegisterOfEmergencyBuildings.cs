using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // Реестр Аварийных Зданий
    public class RegisterOfEmergencyBuildings
    {
        public RegisterOfEmergencyBuildings()
        {
            this.PhotographicFixation = new HashSet<PhotographicFixation>();
        }

        public int IdRegisterOfEmergencyBuildings { get; set; } // id
        // микрорайон
        public int? MicrodistrictId { get; set; }

        // Номер участка ЖКС/ХБ
        public string SectorNumber { get; set; }
       
        // Тип здания
        public int? BuildingTypeId { get; set; }
     
        // Форма собствености
        public int? TypeOfOwnershipId { get; set; }

        public int? AddressingId { get; set; } // Адресс   
        public string TypeOfDestruction { get; set; } // Характер разрушения
        public string TypeBuildings { get; set; } // тип функционального использования здания
        public string Description { get; set; } // Описание разрушения 
        public string JobDescription{ get; set; } // Возможность востановления 
        public int? PhotographicFixationId { get; set; } // Фото
        public int? PossibilityOfReconstructionId { get; set; } // Результат обследования 
        public string Note { get; set; } // Примечание 

        public virtual Addressing Addressing { get; set; }
        public virtual TypeOfOwnership TypeOfOwnership { get; set; }
        public virtual BuildingType BuildingType { get; set; }
        public virtual Microdistrict Microdistrict { get; set; }
        public virtual ICollection<PhotographicFixation> PhotographicFixation { get; set; }
        public virtual PossibilityOfReconstruction PossibilityOfReconstruction { get; set; }

    }
}
