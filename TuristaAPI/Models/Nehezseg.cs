using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TuristaAPI.Models;

public partial class Nehezseg
{
    public int Id { get; set; }

    public string? Jelzes { get; set; }

    public string? Leiras { get; set; }

    [JsonIgnore]
    public virtual ICollection<Utvonal> Utvonals { get; set; } = new List<Utvonal>();
}
