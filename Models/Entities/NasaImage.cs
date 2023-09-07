using System;
using System.Collections.Generic;

namespace NasaApolo.Models.Entities;

public partial class NasaImage
{
    public int IdNasaImage { get; set; }

    public string? Href { get; set; }

    public string? Center { get; set; }

    public string? Title { get; set; }

    public string? NasaId { get; set; }

    public DateTime? Createdate { get; set; }
}
