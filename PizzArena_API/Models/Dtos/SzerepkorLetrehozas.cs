using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models.Dtos
{
    public class SzerepkorLetrehozas
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nev { get; set; }
    }
}
