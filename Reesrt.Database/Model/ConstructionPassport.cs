using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    // Строительный_паспорт
    public class ConstructionPassport
    {
        public int IdConstructionPassport { get; set; }
        public DateTime? OrderIssued { get; set; } // Дата видачі
        public string AuthorityName { get; set; } // Назва органу
        public string ApplicantName { get; set; } // Ім'я або назва замовника
        public int? ApplicantIdentifier { get; set; } // Ідентифікатор замовника
        public int? AuthoritytIdentifier { get; set; } // Ідентифікатор органу
        public string Type { get; set; } // Вид будівництва
        public string Name { get; set; } // Назва об'єкта
        public int? LandId { get; set; } // Кадастровий номер
        public int? AddressingId { get; set; } // Адрес, Поштовий індекс
        public string Status { get; set; } // Статус
        public string ChangesDescription { get; set; } // Зміни
        public string CancellationDescription { get; set; } // Скасування
        public string Url { get; set; } // Посилання

        public virtual Addressing Addressing { get; set; }
        public virtual Land Land { get; set; }
    }
}
