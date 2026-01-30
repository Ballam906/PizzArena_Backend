using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TuristaAPI.Models;

public partial class Turavezeto
{
    public int Id { get; set; }

    public string? Nev { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public int? Minosites { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tura> Turas { get; set; } = new List<Tura>();
}
