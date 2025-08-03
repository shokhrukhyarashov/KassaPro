using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class SoftCredential
{
    public ulong Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
