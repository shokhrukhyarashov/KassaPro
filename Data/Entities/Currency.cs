using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Currency
{
    public ulong Id { get; set; }

    public string? Country { get; set; }

    public string? CurrencyCode { get; set; }

    public string? CurrencySymbol { get; set; }

    public decimal? ExchangeRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
