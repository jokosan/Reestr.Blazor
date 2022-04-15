using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Model
{
    // Архив проектов
    public class ProjectArchiveLogics
    {
        public int IdProjectArchive { get; set; }
        public int? Year { get; set; }
        public int? ProjectNumber { get; set; }
        public string Customer { get; set; }
        public string ProjectOrganization { get; set; }
        public string ProjectName { get; set; }
        public int? AddressingId { get; set; }
        public DateTime? DateRegistration { get; set; }
        public DateTime? VarianceApprovalDate { get; set; }
        public bool Status { get; set; }

        public virtual AddressingLogics Addressing { get; set; }
    }
}
