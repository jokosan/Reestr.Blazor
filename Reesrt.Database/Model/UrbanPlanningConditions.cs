﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // МУО
    public class UrbanPlanningConditions
    {
        public int IdUrbanPlanningConditions { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderIssued { get; set; }
        public string AuthorityName { get; set; }
        public string ApplicantName { get; set; } // Ім'я або назва замовника
        public int? ApplicantIdentifier { get; set; } // Ідентифікатор замовника
        public int? AuthoritytIdentifier { get; set; } // Ідентифікатор органу
        public int? TypeOfConstructionId { get; set; } // Вид будівництва
        public string Name { get; set; } // Назва об'єкта
        public int? LandId { get; set; } // Кадастровий номер
        public int? AddressingId { get; set; } // Адрес, Поштовий індекс
        public string Addressing { get; set; }
        public int? DocumentStatusId { get; set; } // Статус
        public string ChangesDescription { get; set; } // Зміни
        public string CancellationDescription { get; set; } // Скасування
        public string Url { get; set; } // Посилання

        public virtual Land Land { get; set; }
        public virtual DocumentStatus DocumentStatus { get; set; }
        public virtual TypeOfConstruction TypeOfConstruction { get; set; }
    }
}
