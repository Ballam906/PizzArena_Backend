using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzArena_API.Models
{
    public class Rendeles
    {
        [Key]
        public int Id { get; set; }
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
        [ForeignKey(nameof(Fiok))]
        public Guid Felhasznalo_Id { get; set; }

        [JsonIgnore]
        public Fiok Fiok { get; set; }
        public DateTime RendIdo { get; set; } = DateTime.Now;
    }
}
