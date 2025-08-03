using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Admin
{
    public ulong Id { get; set; }

    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Image { get; set; }

    public long? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public long? RoleId { get; set; }
    public virtual AdminRole? AdminRole { get; set; }
    public virtual ICollection<AccessToken> AccessTokens { get; set; } = new List<AccessToken>();

    public virtual ICollection<ProductStockIn> ProductStockIns { get; set; } = new List<ProductStockIn>();
}
