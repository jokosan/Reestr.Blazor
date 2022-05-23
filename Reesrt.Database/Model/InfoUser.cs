using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Model
{
    public class InfoUser
    {
        public int IdInfoUser { get; set; }
        public string InfoUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string PlaceOfWork { get; set; }
        public string Note { get; set; }
        public DateTime? DateOfRegistration { get; set; }
    }
}
