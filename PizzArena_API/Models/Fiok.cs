using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models
{
    public class Fiok
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Felhasznalonev { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        public string Jelszo { get; set; }

        [Required]
        public DateTime RegisztracioIdeje { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid SzerepkorId { get; set; }

        [ForeignKey(nameof(SzerepkorId))]
        public Szerepkor Szerepkor { get; set; }
    }
}
