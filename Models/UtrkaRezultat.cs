using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.Models
{
    public class UtrkaRezultat
    {
        public int UtrkaRezultatID { get; set; }
        [Required(ErrorMessage ="Potrebno je upisati ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Potrebno je upisati prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Potrebno je upisati Vaše vrijeme u formatu h:m:s")]
        [Display(Name ="Vrijeme (h:m:s)")]
        public TimeSpan RezultatVrijeme { get; set; }
        [Display(Name = "Vrijeme službeno")]
        public bool Sluzben { get; set; }
        public int UtrkaID { get; set; }

        public virtual Utrka Utrka { get; set; }
    }
}
