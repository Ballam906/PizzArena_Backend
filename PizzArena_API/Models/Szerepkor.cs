using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PizzArena_API.Models
{
    public class Szerepkor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nev { get; set; }

        public ICollection<Fiok> Fiokok { get; set; }
    }
}
