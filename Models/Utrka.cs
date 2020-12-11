using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.Models
{
    public class Utrka
    {
        public int UtrkaID { get; set; }
        public string Naziv { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##} km", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Duljina { get; set; }
        public DateTime Datum { get; set; }
        public List<UtrkaRezultat> Rezultati { get; set; }

    }
}
