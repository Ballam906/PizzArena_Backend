using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzArena_API.Models.Dtos
{
    public class RendelesLetrehozas
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

        [Required]
        [Column(TypeName = "char(36)")]
        public Guid Felhasznalo_Id { get; set; }
        [Required]
        public DateTime RendIdo { get; set; } = DateTime.Now;
    }
}
