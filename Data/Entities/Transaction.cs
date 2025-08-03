using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Transaction
{
    public ulong Id { get; set; }

    public string? TranType { get; set; }

    public ulong? AccountId { get; set; }
    public virtual Account? Account { get; set; }

    public double? Amount { get; set; }

    public string? Description { get; set; }

    public bool? Debit { get; set; }

    public bool? Credit { get; set; }

    public double? Balance { get; set; }

    public DateOnly? Date { get; set; }

    public ulong? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

    public ulong? SupplierId { get; set; }
    public virtual Supplier? Supplier { get; set; }

    public ulong? OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ulong? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}

