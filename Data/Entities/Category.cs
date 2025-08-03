

namespace KassaPro.Data.Entities;

public  class Category
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;


    public int Position { get; set; }

    public bool? Status { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

}
