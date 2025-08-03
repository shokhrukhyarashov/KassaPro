using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Product
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public ulong? UnitId { get; set; }
    public virtual Unit? Unit { get; set; }

    public double? UnitValue { get; set; }

    public ulong? BrandId { get; set; }
    public virtual Brand? Brand { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public ulong? CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public ulong? SubCategoryId { get; set; }
    public virtual SubCategory? SubCategory { get; set; }

    public decimal? PurchasePrice { get; set; }

    public decimal? SellingPrice { get; set; }

    public string? DiscountType { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Tax { get; set; }

    public long? Quantity { get; set; }

    public string? Image { get; set; }

    public uint? OrderCount { get; set; }

    public ulong? SupplierId { get; set; }
    public virtual ICollection<ProductStockIn> ProductStockIns { get; set; } = new List<ProductStockIn>();


    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
