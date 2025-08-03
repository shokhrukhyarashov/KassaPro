using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Order
{
    public ulong Id { get; set; }

    public ulong? UserId { get; set; }

    public double OrderAmount { get; set; }

    public double TotalTax { get; set; }

    public double? CollectedCash { get; set; }

    public double? ExtraDiscount { get; set; }

    public string? CouponCode { get; set; }

    public double CouponDiscountAmount { get; set; }

    public string? CouponDiscountTitle { get; set; }

    public ulong? PaymentId { get; set; }

    public string? TransactionReference { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
}
