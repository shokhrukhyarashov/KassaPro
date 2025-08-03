using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class OrderDetail
{
    public ulong Id { get; set; }

    public ulong? ProductId { get; set; }

    public long? OrderId { get; set; }

    public double Price { get; set; }

    public string? ProductDetails { get; set; }

    public double? DiscountOnProduct { get; set; }

    public string DiscountType { get; set; } = null!;

    public int Quantity { get; set; }

    public double TaxAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
}
