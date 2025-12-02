using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models.Dtos
{
    public class KategoriaFrissites
    {
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nev { get; set; }
    }
}
