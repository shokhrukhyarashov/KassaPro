using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Account
{
    public ulong Id { get; set; }

    public string Account1 { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Balance { get; set; }

    public string AccountNumber { get; set; } = null!;

    public decimal? TotalIn { get; set; }

    public decimal? TotalOut { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}
