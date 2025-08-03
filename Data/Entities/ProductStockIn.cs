namespace KassaPro.Data.Entities;
public partial class ProductStockIn
{

    public ulong Id { get; set; }

    public ulong ProductId { get; set; }

    public double Quantity { get; set; }

    public double PurchasePrice { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ulong CreatedByAdminId { get; set; } 

    public long? CompanyId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Admin CreatedBy { get; set; } = null!;

    public virtual Company? Company { get; set; }
}
