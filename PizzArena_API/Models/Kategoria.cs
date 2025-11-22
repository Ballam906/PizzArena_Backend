using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models
{
    public class Kategoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nev { get; set; }

        public ICollection<Termek> Termekek { get; set; }
    }
}
