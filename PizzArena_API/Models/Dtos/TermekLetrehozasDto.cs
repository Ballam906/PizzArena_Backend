using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models.Dtos
{
    public class TermekLetrehozasDto
    {
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nev { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Leiras { get; set; }
        [Required]
        public int Ar { get; set; }
        [Required]
        public int Kategoria_Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Kep_Url { get; set; }
    }
}
