using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzArena_API.Models
{
    public class Rendeles_Termek
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public int DbAr { get; set; }

        [Required]
        public int Darab { get; set; }

        [Required]
        public int Rendeles_Id { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Rendeles_Id))]
        public Rendeles Rendeles { get; set; }


        [Required]
        public int Termek_Id { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Termek_Id))]
        public Termek Termek { get; set; }


    }
}
