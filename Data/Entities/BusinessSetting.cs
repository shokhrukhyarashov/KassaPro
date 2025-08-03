using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class BusinessSetting
{
    public ulong Id { get; set; }

    public string Key { get; set; } = null!;

    public string? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company?  Company { get; set; }
}
