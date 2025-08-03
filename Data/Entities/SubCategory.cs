
namespace KassaPro.Data.Entities;

public class SubCategory
{
    public ulong Id { get; set; }
    public string Name { get; set; } = null!;
    public ulong? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public int Position { get; set; }
    public bool? Status { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public string? CompanyName { get; set; }
    public string? ParentCategoryName { get; set; }
     public virtual ICollection<Product> Products { get; set; } = new List<Product>();

}
