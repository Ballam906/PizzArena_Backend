using System.Text.Json.Serialization;
using TuristaAPI.Models;

namespace TuristaAPI.Dtos
{
    public class TuravezetoModDto
    {

        public string? Nev { get; set; }

        public string? Telefon { get; set; }

        public string? Email { get; set; }

        public int? Minosites { get; set; }
    }
}
