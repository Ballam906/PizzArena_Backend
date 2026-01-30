using System.Text.Json.Serialization;
using TuristaAPI.Models;

namespace TuristaAPI.Dtos
{
    public class UtvonalUjDto
    {

        public string? Allomasok { get; set; }

        public int? Tav { get; set; }

        public int? Szint { get; set; }

        public int? NehezsegId { get; set; }
    }
}
