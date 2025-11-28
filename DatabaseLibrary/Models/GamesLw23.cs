using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class GamesLw23
{
    public int IdGame { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdCategory { get; set; }

    public decimal Price { get; set; }

    public string? LogoFile { get; set; }

    public virtual ICollection<ScreenshotsLw23> ScreenshotsLw23s { get; set; } = new List<ScreenshotsLw23>();
}
