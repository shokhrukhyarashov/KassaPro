using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Transaction
{
    public ulong Id { get; set; }

    public string? TranType { get; set; }

    public ulong? AccountId { get; set; }

    public double? Amount { get; set; }

    public string? Description { get; set; }

    public bool? Debit { get; set; }

    public bool? Credit { get; set; }

    public double? Balance { get; set; }

    public DateOnly? Date { get; set; }

    public uint? CustomerId { get; set; }

    public uint? SupplierId { get; set; }

    public uint? OrderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CompanyId { get; set; }
}
