using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace PizzArena_API.Models
{
    public class Szerepkor
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nev { get; set; }

        [JsonIgnore]
        public ICollection<Fiok> Fiokok { get; set; }
    }
}
