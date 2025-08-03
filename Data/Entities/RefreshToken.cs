namespace KassaPro.Data.Entities;
public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; } = null!;
    public string AdminId { get; set; } = null!; // yoki AdminId
    public DateTime ExpiryDate { get; set; }
    public bool IsRevoked { get; set; } = false;
}