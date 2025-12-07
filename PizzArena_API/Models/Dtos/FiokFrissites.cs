using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models.Dtos
{
    public class FiokFrissites
    {
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
        [Column(TypeName = "char(36)")]
        public Guid SzerepkorId { get; set; }

    }
}
