using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class AdminRole
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Modules { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
