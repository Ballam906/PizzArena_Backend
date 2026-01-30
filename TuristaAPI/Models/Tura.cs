using System;
using System.Collections.Generic;

namespace TuristaAPI.Models;

public partial class Tura
{
    public int Id { get; set; }

    public DateTime? Idopont { get; set; }

    public int? UtvonalId { get; set; }

    public int? TuravezetoId { get; set; }

    public int? Koltseg { get; set; }

    public int? Maxletszam { get; set; }

    public virtual Turavezeto? Turavezeto { get; set; }

    public virtual Utvonal? Utvonal { get; set; }
}
