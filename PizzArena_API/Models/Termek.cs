using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models
{
    public class Termek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nev { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Leiras { get; set; }
        public int Ar { get; set; }
        public int Kategoria_Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Kep_Url { get; set; }
        public DateTime RegIdo { get; set; } = DateTime.Now;
        public DateTime ModIdo { get; set; } = DateTime.Now;
    }
}
