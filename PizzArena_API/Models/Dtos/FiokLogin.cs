using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzArena_API.Models.Dtos
{
    public class FiokLogin
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Felhasznalonev { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        public string Jelszo { get; set; }
    }
}
