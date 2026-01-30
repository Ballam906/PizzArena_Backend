using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TuristaAPI.Models;

public partial class Utvonal
{
    public int Id { get; set; }

    public string? Allomasok { get; set; }

    public int? Tav { get; set; }

    public int? Szint { get; set; }

    public int? NehezsegId { get; set; }

    public virtual Nehezseg? Nehezseg { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tura> Turas { get; set; } = new List<Tura>();
}
