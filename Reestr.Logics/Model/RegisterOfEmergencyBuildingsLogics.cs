using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    // Реестр Аварийных Зданий
    public class RegisterOfEmergencyBuildingsLogics
    {
        public int IdRegisterOfEmergencyBuildings { get; set; } // id
        public int? AddressingId { get; set; } // Адресс   
        public string TypeOfDestruction { get; set; } // Вид разрушения
        public string TypeBuildings { get; set; } // тип функционального использования здания
        public bool? DocumentationCompliance { get; set; } // зона нахождения в зонингу и гп 
        public string TypeOfOwnership { get; set; } // форма собственности
        public string Description { get; set; } // Описание разрушения 
        public string JobDescription{ get; set; } // описания проделанных работ 
        public int? PhotographicFixationId { get; set; } // Фото
        public int? PossibilityOfReconstructionId { get; set; } // Результат обследования 
        public string Note { get; set; } // Примечание 

        public virtual AddressingLogics Addressing { get; set; }
    }
}
