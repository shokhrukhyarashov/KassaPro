using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Coupon
{
    public ulong Id { get; set; }

    public string? Title { get; set; }

    public string CouponType { get; set; } = null!;

    public int? UserLimit { get; set; }

    public string? Code { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? ExpireDate { get; set; }

    public decimal MinPurchase { get; set; }

    public decimal MaxDiscount { get; set; }

    public decimal Discount { get; set; }

    public string DiscountType { get; set; } = null!;

    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}
