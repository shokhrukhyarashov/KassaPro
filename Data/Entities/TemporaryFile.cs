using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class TemporaryFile
{
    public ulong Id { get; set; }

    public string Folder { get; set; } = null!;

    public string Filename { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
