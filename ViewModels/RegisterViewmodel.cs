using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.ViewModels
{
    public class RegisterViewmodel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Potvrdi lozinku")]
        [Compare("Lozinka", ErrorMessage ="Lozinke se ne podudaraju")]
        public string PotvrdiLozinku { get; set; }
    }
}
