using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reestr.Blazor.Areas.Identity.ViewModel
{
    public class User : IdentityUser
    {
        // Районная администрация/ Департамент 
        [Required]
        public string Department { get; set; }

        // Должность 
        [Required]
        public string Position { get; set; }

        // ФИО
        [Required]
        public string FullName { get; set; }
    }
}
