using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Unit
{
    public ulong Id { get; set; }

    public string UnitType { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
