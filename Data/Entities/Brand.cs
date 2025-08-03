using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Brand
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}
