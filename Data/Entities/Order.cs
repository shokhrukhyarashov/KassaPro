using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Order
{
    public ulong Id { get; set; }

    public ulong? UserId { get; set; }
    public virtual User? User { get; set; }
    public decimal OrderAmount { get; set; }

    public decimal TotalTax { get; set; }

    public decimal? CollectedCash { get; set; }

    public decimal? ExtraDiscount { get; set; }

    public string? CouponCode { get; set; }

    public decimal CouponDiscountAmount { get; set; }

    public string? CouponDiscountTitle { get; set; }

    public string? TransactionReference { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public ulong? TranId { get; set; }
    public virtual Transaction? Tran { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
