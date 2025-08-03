using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Product
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public uint? UnitType { get; set; }

    public double? UnitValue { get; set; }

    public string? Brand { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public ulong? CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public ulong? SubCategoryId { get; set; }
    public virtual SubCategory? SubCategory { get; set; }

    public double? PurchasePrice { get; set; }

    public double? SellingPrice { get; set; }

    public string? DiscountType { get; set; }

    public double? Discount { get; set; }

    public double? Tax { get; set; }

    public long? Quantity { get; set; }

    public string? Image { get; set; }

    public uint? OrderCount { get; set; }

    public uint? SupplierId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
