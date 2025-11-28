using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class ScreenshotsLw23
{
    public int ScreenshotId { get; set; }

    public int GameId { get; set; }

    public string FileName { get; set; } = null!;

    public byte[] Photo { get; set; } = null!;

    public virtual GamesLw23 Game { get; set; } = null!;
}
