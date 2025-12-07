using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models.Dtos
{
    public class RendelesFrissites
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nev { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string VasarloTelszam { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string SzallitasiCim { get; set; }
    }
}
