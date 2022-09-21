using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class InformationAboutDestruction
    {

        public int IdInformationAboutDestruction { get; set; }
        public int? RegisterOfEmergencyBuildingsId { get; set; }
        // Конструкции здания 
        public bool BuildingStructures { get; set; }
        // Полное разрушение здания
        public bool CompleteDestructionOfTheBuilding { get; set; }
        // Повреждения конструкция
        public bool DamageDesign { get; set; }
        // Разрушено цокольного этажа
        public bool DestroyedBasement { get; set; }
        // Разрушение кровли 
        public bool RoofDestruction { get; set; }
        //  Разрушения фасада 
        public bool Quantity { get; set; }
        // Разрушение балконов
        public bool GlazingDamage { get; set; }
        public int? GlazingDamageQuantity { get; set; }
        // Повреждения остеклений 
        public bool BalconiesDestroyed { get; set; }
        public int? BalconiesDestroyedQuantity { get; set; }
        // Разрушено подъездов
        public bool DestroyedEntrances { get; set; }
        // Повреждено лифтов
        public bool DamagedElevators { get; set; }
        public bool Electricity { get; set; }
        public bool Gas { get; set; }
        public bool ColdWater { get; set; }
        public bool HotWater { get; set; }
        public bool Heating { get; set; }
        public DateTime? date {get; set;}

        public virtual RegisterOfEmergencyBuildings RegisterOfEmergencyBuildings { get; set; }
    }
}
