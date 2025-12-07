using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzArena_API.Models.Dtos
{
    public class RendelesItemLetrehozas
    {

        [Required]
        public int DbAr { get; set; }

        [Required]
        public int Darab { get; set; }

        [Required]
        public int Rendeles_Id { get; set; }


        [Required]
        public int Termek_Id { get; set; }
    }
}
